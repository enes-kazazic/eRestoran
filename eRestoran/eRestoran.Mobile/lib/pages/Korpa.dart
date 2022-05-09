import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:restoran_seminarski/services/APIService.dart';
import 'package:restoran_seminarski/services/CartService.dart';
import 'package:flutter_stripe/flutter_stripe.dart' hide Card;
import 'package:http/http.dart' as http;

class Korpa extends StatefulWidget {
  @override
  _KorpaState createState() => _KorpaState();
}

class _KorpaState extends State<Korpa> {
  Map<String, dynamic>? paymentIntentData;
  double iznos = 0;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: const Text('Korpa'),
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    return Column(
      children: [
        CartService.products.isNotEmpty
            ? Expanded(
                child: ListView(
                children: CartService.products.values
                    .map((e) => JelaWidget(e))
                    .toList(),
              ))
            : Container(),
        Padding(
            padding: const EdgeInsets.all(8.0),
            child: CartService.products.isNotEmpty
                ? Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Row(
                        children: [
                          const Text("Ukupno:",
                              style: TextStyle(
                                  fontWeight: FontWeight.bold, fontSize: 20)),
                          const SizedBox(width: 10),
                          Text(CartService.Ukupno.toString() + " KM",
                              style: const TextStyle(fontSize: 20))
                        ],
                      ),
                      const SizedBox(
                        height: 10,
                      ),
                      ElevatedButton(
                          onPressed: () async {
                            makePayment(
                                double.parse(CartService.Ukupno.toString()));
                          },
                          style: ElevatedButton.styleFrom(
                              primary: const Color.fromARGB(200, 239, 108, 0),
                              minimumSize: const Size.fromHeight(50)),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            // ignore: prefer_const_literals_to_create_immutables
                            children: [
                              const Text("Nastavi na placanje",
                                  style: TextStyle(fontSize: 20)),
                              const Icon(
                                Icons.arrow_forward_rounded,
                                size: 30,
                              )
                            ],
                          )),
                    ],
                  )
                : const Text("Korpa je prazna.",
                    style: TextStyle(fontSize: 18)))
      ],
    );
  }

  Widget JelaWidget(cart) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(10),
        child: Row(
          children: [
            SizedBox(
              width: 100,
              height: 100,
              child: FittedBox(
                fit: BoxFit.fill,
                child: cart.proizvod.Slika.isNotEmpty
                    ? Image(
                        image: MemoryImage(cart.proizvod.Slika),
                      )
                    : Icon(Icons.not_interested),
              ),
            ),
            // ignore: prefer_const_constructors
            SizedBox(
              width: 20,
            ),
            Expanded(
              child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text(cart.proizvod.Naziv,
                            style: const TextStyle(
                                color: Colors.black,
                                fontSize: 18,
                                fontWeight: FontWeight.bold)),
                        Container(
                          width: 40,
                          height: 40,
                          decoration: const BoxDecoration(
                              shape: BoxShape.circle, color: Colors.blue),
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            // ignore: prefer_const_literals_to_create_immutables
                            children: [
                              Text(cart.kolicina.toString(), //kolicina
                                  // ignore: prefer_const_constructors
                                  style: TextStyle(
                                      color: Colors.white,
                                      fontSize: 20,
                                      fontWeight: FontWeight.bold)),
                            ],
                          ),
                        )
                      ],
                    ),
                    const SizedBox(height: 5),
                    Text(cart.proizvod.Opis,
                        overflow: TextOverflow.ellipsis,
                        style: TextStyle(
                            color: Colors.grey[600],
                            fontSize: 16,
                            fontWeight: FontWeight.bold)),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Row(
                          children: [
                            TextButton(
                                onPressed: () {
                                  setState(() {
                                    CartService.decreaseQuantity(cart.proizvod);
                                  });
                                },
                                child: const Icon(Icons.remove)),
                            TextButton(
                                onPressed: () {
                                  setState(() {
                                    CartService.addProduct(cart.proizvod, 1);
                                  });
                                },
                                child: const Icon(Icons.add)),
                          ],
                        ),
                        Padding(
                          padding: const EdgeInsets.all(10),
                          child: Text(cart.proizvod.Cijena.toString() + '0 KM',
                              style: const TextStyle(
                                color: Colors.black,
                                fontSize: 20,
                                fontWeight: FontWeight.bold,
                              )),
                        )
                      ],
                    )
                  ]),
            ),
          ],
        ),
      ),
    );
  }

  Future<void> makePayment(double iznos) async {
    try {
      paymentIntentData =
          await createPaymentIntent((iznos * 100).round().toString(), 'bam');
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
                'Bearer sk_test_51Kw3twKAtqE1XPaPvJCz3zdLuAv2DxM8s8dO5cWrzN1k5GbPgrsSfeltNJeBxSJyeGJbMVnhROZDFXt4KZQ67SMP00gnQfMrbo',
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

      await InsertStavkeNarudzbe();

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

  Future<void> InsertStavkeNarudzbe() async {
    await APIService.post(
        "StavkeNarudzbe/InsertAll",
        json.encode(
            CartService.products.values.map((e) => e.toJson()).toList()));
    setState(() {
      paymentIntentData = null;
      CartService.clear();
    });
  }
}
