import 'package:counter/counter.dart';
import 'package:flutter/material.dart';

class Korpa extends StatefulWidget {
  @override
  _KorpaState createState() => _KorpaState();
}

class _KorpaState extends State<Korpa> {
  bool swapWidget = false;
  var rating = 0.0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Korpa'),
      ),
      body: bodyWidget(),
    );
  }

  Widget bodyWidget() {
    return Container(
      child: Counter(min: 0, max: 5),
    );
  }
}
