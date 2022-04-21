import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/CartModel.dart';
import 'package:restoran_seminarski/models/Jelo.dart';
import 'package:restoran_seminarski/models/Narudzba.dart';
import 'package:restoran_seminarski/models/NarudzbaStavke.dart';
import 'package:restoran_seminarski/services/APIService.dart';
import 'package:restoran_seminarski/services/CartService.dart';

class Korpa extends StatefulWidget {
  @override
  _KorpaState createState() => _KorpaState();
}

class _KorpaState extends State<Korpa> {
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
        CartService.products.isNotEmpty ? 
        Expanded(
            child: ListView(
          children:
              CartService.products.values.map((e) => JelaWidget(e)).toList(),
        )) : Container(),
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: CartService.products.isNotEmpty ? ElevatedButton(
            onPressed: () async {
                await APIService.post("StavkeNarudzbe/InsertAll", json.encode(CartService.products.values.map((e) => e.toJson()).toList()));
                setState(() {
                  CartService.clear();
                  Navigator.of(context).pop();
                });
                // print("Stavke narudzbe ->" + narudzbaStavkeRequest.toString());
              }, 
            style: ElevatedButton.styleFrom(
              primary: const Color.fromARGB(200, 239, 108, 0),
              minimumSize: const Size.fromHeight(50)
            ),
            child: const Text(
              'Naruči',
              style: TextStyle(fontSize: 20)
              )
            )  : Container(
              child: const Text("Korpa je prazna.", style: TextStyle(fontSize: 18)),
            )
        )
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
                child: Image(
                  image: MemoryImage(cart.proizvod.Slika),
                ),
              ),
            ),
            // ignore: prefer_const_constructors
            SizedBox(
              width:  20,
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
                        shape: BoxShape.circle,
                        color: Colors.blue
                      ),
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
                        TextButton(onPressed: () { 
                          setState(() {
                            CartService.decreaseQuantity(cart.proizvod); 
                          });
                          }, 
                          child: const Icon(Icons.remove)),
                        TextButton(onPressed: () { 
                          setState(() {
                            CartService.addProduct(cart.proizvod, 1); 
                          });
                          }, 
                          child: const Icon(Icons.add)),
                      ],
                    ),
                    Padding(
                      padding: const EdgeInsets.all(10),
                      child: Text(cart.proizvod.Cijena + '0 KM',
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
}
