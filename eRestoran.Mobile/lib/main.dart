import 'package:flutter/material.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:restoran_seminarski/pages/Korpa.dart';
import 'package:restoran_seminarski/pages/Login.dart';
import 'package:restoran_seminarski/pages/Home.dart';
import 'package:restoran_seminarski/pages/Narudzbe.dart';
import 'package:restoran_seminarski/pages/Jela.dart';
import 'package:restoran_seminarski/pages/Profil.dart';

void main() {
  Stripe.publishableKey =
      "pk_test_51Kw3twKAtqE1XPaPXoIuYPB5pCRHpiLr7Dfkhl3fDIP9vH4fUQqEYMtwgdqAvH1l3BjAu0a5HEgSlUkksSiYwoPC00s8OhYRW1";
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Login(),
      routes: {
        'Home': (context) => Home(),
        'Jela': (context) => Jela(),
        'Korpa': (context) => Korpa(),
        'Narudzbe': (context) => Narudzbe(),
        'Profil': (context) => Profil()
      },
    );
  }
}
