import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:restoran_seminarski/models/Narudzba.dart';
import 'package:restoran_seminarski/services/APIService.dart';

class Narudzbe extends StatefulWidget {
  @override
  _NaruzdbeState createState() => _NaruzdbeState();
}

class _NaruzdbeState extends State<Narudzbe> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Moje narudžbe'),
        ),
        body: bodyWidget());
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Narudzba>>(
      future: GetNaruzdbe(),
      builder: (BuildContext context, AsyncSnapshot<List<Narudzba>?> snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return Center(child: Text('Loading..'));
        } else {
          if (snapshot.hasError) {
            return Center(child: Text('Error:${snapshot.error}'));
          } else {
            return ListView(
              children: snapshot.data!.map((e) => NarudzbaWidget(e)).toList(),
            );
          }
        }
      },
    );
  }

  Widget NarudzbaWidget(Naruzdba) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(25),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            SizedBox(
              width: 40,
              height: 40,
              child: FittedBox(
                child: Icon(Naruzdba.statusNarudzbeId == 1
                    ? Icons.add_task_outlined
                    : Naruzdba.statusNarudzbeId == 2
                        ? Icons.assignment_turned_in_outlined
                        : Naruzdba.statusNarudzbeId == 3
                            ? Icons.check_circle_sharp
                            : Icons.not_accessible),
              ),
            ),
            Text(
                DateFormat('dd.MM.yyyy hh:mm')
                    .format(Naruzdba.DatumNarudzbe)
                    .toString(),
                // ignore: prefer_const_constructors
                style: TextStyle(
                  color: Colors.black,
                  fontSize: 16,
                )),
            SizedBox(height: 5),
            Text(Naruzdba.statusNarudzbe,
                style: const TextStyle(
                    color: Colors.black,
                    fontSize: 18,
                    fontWeight: FontWeight.bold)),
          ],
        ),
      ),
    );
  }

  Future<List<Narudzba>> GetNaruzdbe() async {
    Map<String, String>? queryParams = {
      'KorisnikId': APIService.korisnikId.toString()
    };
    var narudzbe = await APIService.Get('Narudzba', queryParams);
    return narudzbe!.map((i) => Narudzba.fromJson(i)).toList();
  }
}
