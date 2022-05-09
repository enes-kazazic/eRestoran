import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:restoran_seminarski/models/Korisnik.dart';
import 'package:restoran_seminarski/services/APIService.dart';

class Profil extends StatefulWidget {
  @override
  _ProfilState createState() => _ProfilState();
}

class _ProfilState extends State<Profil> {
  final _validationKey = GlobalKey<FormState>();

  TextEditingController imeController = TextEditingController();
  TextEditingController prezimeController = TextEditingController();
  TextEditingController korisnickoImeController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Moj profil'),
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    final txtIme = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Obavezno polje" : null;
      },
      controller: imeController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtPrezime = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Obavezno polje" : null;
      },
      controller: prezimeController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Prezime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    final txtUsername = TextFormField(
      validator: (value) {
        return value == null || value.isEmpty ? "Obavezno polje" : null;
      },
      controller: korisnickoImeController,
      obscureText: false,
      decoration: InputDecoration(
          contentPadding: const EdgeInsets.fromLTRB(20.0, 15.0, 20.0, 15.0),
          hintText: "Korisnicko ime",
          border:
              OutlineInputBorder(borderRadius: BorderRadius.circular(32.0))),
    );

    Widget ProfilWidget(korisnik) {
      imeController.text = korisnik.Ime;
      prezimeController.text = korisnik.Prezime;
      korisnickoImeController.text = korisnik.KorisnickoIme;
      return Center(
        child: Padding(
          padding: const EdgeInsets.all(20),
          child: Column(
            children: [
              const Icon(Icons.portrait, size: 80),
              const SizedBox(height: 50),
              Form(
                  key: _validationKey,
                  child: Column(
                    children: [
                      txtIme,
                      const SizedBox(height: 25),
                      txtPrezime,
                      const SizedBox(height: 25),
                      txtUsername,
                      const SizedBox(height: 40),
                      Container(
                        height: 50,
                        width: 250,
                        decoration: BoxDecoration(
                            color: Colors.red,
                            borderRadius: BorderRadius.circular(20)),
                        child: TextButton(
                          onPressed: () async {
                            var request = Korisnik(
                                KorisnikId: APIService.korisnikId!,
                                Ime: imeController.text,
                                Prezime: prezimeController.text,
                                KorisnickoIme: korisnickoImeController.text);

                            await APIService.put(
                                    "Korisnik",
                                    APIService.korisnikId!,
                                    json.encode(request.toJson()))
                                .then((value) {
                              APIService.username =
                                  korisnickoImeController.text;
                              setState(() {
                                ScaffoldMessenger.of(context)
                                    .showSnackBar(const SnackBar(
                                  content: SizedBox(
                                      height: 20,
                                      child: Center(child: Text("Uspješno"))),
                                  backgroundColor:
                                      Color.fromARGB(255, 9, 100, 13),
                                ));
                              });
                            });
                          },
                          child: const Text('Spremi',
                              style:
                                  TextStyle(color: Colors.white, fontSize: 20)),
                        ),
                      ),
                    ],
                  ))
            ],
          ),
        ),
      );
    }

    return FutureBuilder(
      future: getKorisnik(),
      builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ProfilWidget(snapshot.data);
          }
        }
      },
    );
  }
}

Future<dynamic> getKorisnik() async {
  var korisnik = await APIService.GetById("Korisnik", APIService.korisnikId!);
  return Korisnik.fromJson(korisnik);
}
