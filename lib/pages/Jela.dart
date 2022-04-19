// ignore_for_file: prefer_const_literals_to_create_immutables, prefer_const_constructors

import 'dart:convert';

import 'package:badges/badges.dart';
import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/Jelo.dart';
import 'package:restoran_seminarski/models/Narudzba.dart';
import 'package:restoran_seminarski/models/Recenzija.dart';
import 'package:restoran_seminarski/services/APIService.dart';
import 'package:restoran_seminarski/services/CartService.dart';
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
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
            Text('Jela'),
            Badge(
              badgeContent: Text(CartService.products.length.toString(), 
                                  style: TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold,
                                    )),
              child: Icon(Icons.shopping_cart)
            )
          ])
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
              children:
                  snapshot.data!.map((e) => JelaWidget(e, e.Cijena)).toList(),
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

  Widget JelaWidget(Jelo, Cijena) {
    return Card(
      child: InkWell(
          onTap: () {
            // Navigator.of(context).pushNamed('Korpa');
          },
          child: Padding(
            padding: const EdgeInsets.all(10),
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
                      overflow: TextOverflow.ellipsis,
                      style: TextStyle(
                          color: Colors.grey[600],
                          fontSize: 16,
                          fontWeight: FontWeight.bold)),
                  SmoothStarRating(
                    // rating: double.parse(Jelo.Cijena),
                    starCount: 5,
                    filledIconData: Icons.star,
                    defaultIconData: Icons.star_border,
                    color: Colors.blue,
                    onRatingChanged: ((value) {
                      showModalBottomSheet(
                          isScrollControlled: true,
                          context: context,
                          builder: (BuildContext context) {
                            return recenzijaModal(Jelo, value);
                          });
                    }),
                  ),
                ]),
                Padding(
                  padding: EdgeInsets.all(20),
                  child: Text(Jelo.Cijena + '0 KM',
                      style: TextStyle(
                        color: Colors.black,
                        fontSize: 18,
                        fontWeight: FontWeight.bold,
                      )),
                ),
                // Counter
                // Container(
                //   height: 35,
                //   width: 35,
                //   child: TextField(
                //     style: TextStyle(fontSize: 15),
                //       decoration: InputDecoration(
                //       border: OutlineInputBorder(),
                //     ),
                //     keyboardType: TextInputType.number,
                //   ),
                // ),
                TextButton(
                    onPressed: () {
                      CartService.addProduct(Jelo, 1);
                      setState(() {});
                    },
                    child: addWidget())
              ],
            ),
          )
        ),
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

  Widget saveButton() {
    return Container(
      height: 50,
      width: 120,
      decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(17), color: Colors.blue),
      child: Center(
        child: Text('Sacuvaj',
            style: TextStyle(
                color: Colors.white,
                fontSize: 20,
                fontWeight: FontWeight.bold)),
      ),
    );
  }


  Widget recenzijaModal(Jelo, value) {
    var recenzijaOpisController = TextEditingController();
    
    return Padding(
      padding: MediaQuery.of(context).viewInsets,
      child: Container(
          height: 400,
          child: Padding(
            padding: EdgeInsets.symmetric(horizontal: 20),
            child: Column(  
              mainAxisAlignment: MainAxisAlignment.spaceAround,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                ClipRRect(
                    borderRadius: BorderRadius.circular(30),
                    child: Image(
                      height: 80,
                      width: 80,
                      image: MemoryImage(Jelo.Slika),
                    )),
                Text(Jelo.Naziv,
                    style: TextStyle(
                        color: Colors.black,
                        fontSize: 16,
                        fontWeight: FontWeight.bold)),
                SmoothStarRating(
                  // rating: double.parse(Jelo.Cijena),
                  rating: value,
                  starCount: 5,
                  filledIconData: Icons.star,
                  defaultIconData: Icons.star_border,
                  color: Colors.blue,
                ),
                TextField(
                  controller: recenzijaOpisController,
                  maxLines: 5,
                  decoration: InputDecoration(
                      border: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(10)),
                      hintText: 'Recenzija...'),
                ),
                TextButton(
                    onPressed: () async {
                      var request = Recenzija(
                        Ocjena: 2, 
                        Opis: recenzijaOpisController.text,
                        JeloId: Jelo.JeloId,
                        KorisnikId: 1);

                      await APIService.post("Recenzija", json.encode(request.toJson()));   
                      ScaffoldMessenger.of(context).showSnackBar(SnackBar(
                        content: Center(child: Text("Uspješno")),
                        backgroundColor: Color.fromARGB(255, 9, 100, 13),
                      ));
                      Navigator.pop(context);
                      setState(() {
                      });
                    },
                    child: saveButton())
              ],
            ),
          )),
    );
  }
}