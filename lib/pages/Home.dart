// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'package:flutter/material.dart';

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
          title: Text('Pocetna'),
        ),
        drawer: Drawer(
          child: Column(
            children: [
              AppBar(
                title: const Text("Meni"),
                centerTitle: true,
              ),
              // const Divider(),
              // ListTile(
              //   leading: const Icon(Icons.home),
              //   title: const Text("Pocetna"),
              //   onTap: () {
              //     Navigator.of(context).pushReplacementNamed('/pocetna');
              //   },
              // ),
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
                leading: const Icon(Icons.shopping_cart),
                title: const Text("Korpa"),
                onTap: () {
                  Navigator.of(context).pushNamed('Korpa');
                },
              ),
              // const Divider(),
              // ListTile(
              //   leading: const Icon(Icons.person),
              //   title: const Text("Profil"),
              //   onTap: () {
              //     Navigator.of(context).pushReplacementNamed('/profil');
              //   },
              // ),
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
        ));
  }
}
