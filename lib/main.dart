import 'package:flutter/material.dart';
import 'package:restoran_seminarski/pages/Korpa.dart';
import 'package:restoran_seminarski/pages/Login.dart';
import 'package:restoran_seminarski/pages/Home.dart';
import 'package:restoran_seminarski/pages/Test.dart';
import 'package:restoran_seminarski/pages/Jela.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Home(),
      routes: {'Jela': (context) => Jela(), 'Korpa': (context) => Korpa()},
    );
  }
}
