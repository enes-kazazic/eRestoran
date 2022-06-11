import 'dart:convert';

class Uplata {
  late int? KorisnikId;
  final double Iznos;
  final String BrojTransakcije;
  final DateTime DatumTransakcije;

  Uplata(
      {this.KorisnikId,
      required this.Iznos,
      required this.BrojTransakcije,
      required this.DatumTransakcije});

  Map<String, dynamic> toJson() => {
        "KorisnikId": KorisnikId,
        "Iznos": Iznos,
        "BrojTransakcije": BrojTransakcije,
        "DatumTransakcije": DatumTransakcije.toString(),
      };
}
