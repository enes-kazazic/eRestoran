// ignore_for_file: prefer_const_literals_to_create_immutables, prefer_const_constructors

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/Jelo.dart';
import 'package:restoran_seminarski/services/APIService.dart';
import 'package:smooth_star_rating_null_safety/smooth_star_rating_null_safety.dart';

class Jela extends StatefulWidget {
  @override
  _JelaState createState() => _JelaState();
}

class _JelaState extends State<Jela> {
  bool swapWidget = false;
  var rating = 0.0;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Jela'),
      ),
      body: bodyWidget(),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Jelo>>(
      future: GetJela(),
      builder: (BuildContext context, AsyncSnapshot<List<Jelo>?> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children: snapshot.data!.map((e) => JelaWidget(e)).toList(),
            );
          }
        }
      },
    );
  }

  Future<List<Jelo>> GetJela() async {
    var jela = await APIService.Get('Jelo');
    return jela!.map((i) => Jelo.fromJson(i)).toList();
  }

  Widget JelaWidget(Jelo) {
    return Card(
      child: TextButton(
          style: ButtonStyle(),
          onPressed: () {},
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Image(
                height: 50,
                width: 50,
                image: MemoryImage(Jelo.Slika),
              ),
              Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
                Text(Jelo.Naziv,
                    style: TextStyle(
                        color: Colors.black,
                        fontSize: 16,
                        fontWeight: FontWeight.bold)),
                SizedBox(height: 5),
                Text(Jelo.Opis,
                    style: TextStyle(
                        color: Colors.grey[600],
                        fontSize: 16,
                        fontWeight: FontWeight.bold)),
                SmoothStarRating(
                  rating: double.parse(Jelo.Cijena),
                  filledIconData: Icons.star,
                  onRatingChanged: ((value) {
                    setState(() {
                      rating = value;
                    });
                  }),
                )
              ]),
              // Padding(
              //   padding: EdgeInsets.all(20),
              //   child: Text(Jelo.Cijena + ' KM',
              //       style: TextStyle(
              //         color: Colors.black,
              //         fontSize: 18,
              //         fontWeight: FontWeight.bold,
              //       )),
              // ),
              TextButton(
                  onPressed: () {
                    setState(() {
                      swapWidget = true;
                    });
                  },
                  child: swapWidget ? Text("Test") : addWidget())
            ],
          )),
    );
  }

  Widget addWidget() {
    return Container(
      height: 45,
      width: 45,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(17), color: Colors.blue),
      child: Center(
        child: Icon(
          Icons.add,
          color: Colors.white,
          size: 25,
        ),
      ),
    );
  }
}
