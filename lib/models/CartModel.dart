import 'package:flutter/material.dart';
import 'Jelo.dart';

class CartModel {
  late Jelo proizvod;
  late int kolicina;
  late int? NarudzbaId;
  late int Cijena;

  int? get narudzbaId {
    return NarudzbaId;
  }

  void set narudzbaId(int? value) {
    NarudzbaId = value;
  }

  Map<String, dynamic> toJson() => {
        "Jelo": proizvod.toJson(),
        "Kolicina": kolicina,
        "NarudzbaId": NarudzbaId,
        "Cijena": proizvod.Cijena.round()
      };
}
