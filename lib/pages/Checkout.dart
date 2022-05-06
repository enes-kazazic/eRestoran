import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/http.dart' as http;

import '../services/APIService.dart';
import '../services/CartService.dart';

class Checkout extends StatefulWidget {
  double iznos;

  Checkout(this.iznos);

  @override
  _CheckoutState createState() => _CheckoutState();
}

class _CheckoutState extends State<Checkout> {
  Map<String, dynamic>? paymentIntentData;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Plaćanje'),
      ),
      body: bodyWidget()
    );
  }

  Future<void> StavkeNarudzbeInsert() async {
    await APIService.post(
        "StavkeNarudzbe/InsertAll",
        json.encode(
            CartService.products.values.map((e) => e.toJson()).toList()));
    setState(() {
      CartService.clear();
      Navigator.of(context).pop();
    });
  }

  Future<void> makePayment() async {
    try {
      paymentIntentData =
          await createPaymentIntent(widget.iznos.toString(), 'bam');
      await Stripe.instance
          .initPaymentSheet(
              paymentSheetParameters: SetupPaymentSheetParameters(
                  paymentIntentClientSecret:
                      paymentIntentData!['client_secret'],
                  applePay: true,
                  googlePay: true,
                  testEnv: true,
                  style: ThemeMode.dark,
                  merchantCountryCode: 'BIH',
                  merchantDisplayName: 'Restoran'))
          .then((value) {});

      ///now finally display payment sheeet
      displayPaymentSheet();
    } catch (e, s) {
      print('exception:$e$s');
    }
  }

  createPaymentIntent(String amount, String currency) async {
    try {
      Map<String, dynamic> body = {
        'amount': amount,
        'currency': currency,
        'payment_method_types[]': 'card'
      };

      var response = await http.post(
          Uri.parse('https://api.stripe.com/v1/payment_intents'),
          body: body,
          headers: {
            'Authorization':
                'Bearer pk_test_51Kw3twKAtqE1XPaPXoIuYPB5pCRHpiLr7Dfkhl3fDIP9vH4fUQqEYMtwgdqAvH1l3BjAu0a5HEgSlUkksSiYwoPC00s8OhYRW1',
            'Content-Type': 'application/x-www-form-urlencoded'
          });
      return jsonDecode(response.body);
    } catch (err) {
      print('err charging user: ${err.toString()}');
    }
  }

  displayPaymentSheet() async {
    try {
      await Stripe.instance
          .presentPaymentSheet(
              parameters: PresentPaymentSheetParameters(
        clientSecret: paymentIntentData!['client_secret'],
        confirmPayment: true,
      ))
          .onError((error, stackTrace) {
        print('Exception/DISPLAYPAYMENTSHEET==> $error $stackTrace');
      });

      setState(() {
        paymentIntentData = null;
      });

      ScaffoldMessenger.of(context)
          .showSnackBar(const SnackBar(content: Text("Uplata uspjesna")));
    } on StripeException catch (e) {
      showDialog(
          context: context,
          builder: (_) => const AlertDialog(
                content: Text("Ponistena transakcija"),
              ));
    } catch (e) {
      print('$e');
    }
  }

  Widget bodyWidget(){
    return Center(
      child: InkWell(
        onTap: (() => {
          makePayment()
        }),
        child: Container(
          height: 50,
          width: 50,
          child: Text("Plati"),
        ),
      ),
    );
  }
}
