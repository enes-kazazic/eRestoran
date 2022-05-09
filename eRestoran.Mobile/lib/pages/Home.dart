// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'dart:convert';

import 'package:badges/badges.dart';
import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/Jelo.dart';
import 'package:restoran_seminarski/models/Narudzba.dart';
import 'package:restoran_seminarski/services/APIService.dart';
import 'package:restoran_seminarski/services/CartService.dart';

class Home extends StatefulWidget {
  const Home({Key? key}) : super(key: key);

  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
          title: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text('Pocetna'),
          InkWell(
            onTap: () => {
              Navigator.of(context)
                  .pushNamed('Korpa')
                  .then((_) => setState(() {}))
            },
            child: Badge(
                badgeContent: Text(CartService.products.length.toString(),
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                    )),
                child: Icon(Icons.shopping_cart)),
          )
        ],
      )),
      drawer: Drawer(
        child: Column(
          children: [
            AppBar(
              title: const Text("Meni"),
              centerTitle: true,
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.home),
              title: const Text("Pocetna"),
              onTap: () {
                Navigator.of(context).pushReplacementNamed('Home');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.fastfood),
              title: const Text("Jela"),
              onTap: () {
                Navigator.of(context).pushNamed('Jela');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.delivery_dining_outlined),
              title: const Text("Moje narudzbe"),
              onTap: () {
                Navigator.of(context).pushNamed('Narudzbe');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.shopping_cart),
              title: const Text("Korpa"),
              onTap: () {
                Navigator.of(context).pushNamed('Korpa');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.person),
              title: const Text("Profil"),
              onTap: () {
                Navigator.of(context).pushNamed('Profil');
              },
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.logout),
              title: const Text("Odjava"),
              onTap: () {
                Navigator.of(context).pushReplacementNamed('/');
              },
            ),
          ],
        ),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(10.0),
            child: Align(
              alignment: Alignment.centerLeft,
              child: Text('Preporuceno',
                  style: TextStyle(fontWeight: FontWeight.w600, fontSize: 25)),
            ),
          ),
          Expanded(child: BodyWidget()),
        ],
      ),
    );
  }

  Widget BodyWidget() {
    return FutureBuilder<List<Jelo>?>(
      future: GetPreporuceno(),
      builder: (BuildContext context, AsyncSnapshot<List<Jelo>?> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            print("Data ->" + snapshot.toString());
            return snapshot.hasData
                ? ListView(
                    children: snapshot.data!
                        .map((e) => PreporucenaJelaWidget(e, e.Cijena))
                        .toList(),
                  )
                : Center(
                    child: const Text("Nema dovoljno podataka za prikaz.",
                        style: TextStyle(fontSize: 18)),
                  );
          }
        }
      },
    );
  }

  Widget PreporucenaJelaWidget(Jelo, Cijena) {
    return Card(
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
            ]),
            Padding(
              padding: EdgeInsets.all(20),
              child: Text(Jelo.Cijena.toString() + '0 KM',
                  style: TextStyle(
                    color: Colors.black,
                    fontSize: 18,
                    fontWeight: FontWeight.bold,
                  )),
            ),
            TextButton(
                onPressed: () async {
                  if (CartService.NarudzbaId == null) {
                    var narudzbaRequest = Narudzba(
                        DatumNarudzbe: DateTime.now(),
                        korisnikId: APIService.korisnikId,
                        statusNarudzbeId: 1);

                    var result = await APIService.post(
                        "Narudzba", json.encode(narudzbaRequest.toJson()));
                    CartService.NarudzbaId = result['id'];
                  }

                  CartService.addProduct(Jelo, 1);
                  setState(() {});
                },
                child: addWidget())
          ],
        ),
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

  Future<List<Jelo>?> GetPreporuceno() async {
    var jela = await APIService.Get('Jelo/preporuceno', APIService.korisnikId);
    return jela?.map((i) => Jelo.fromJson(i)).toList();
  }
}
