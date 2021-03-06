import 'dart:convert';

class Jelo {
  final int JeloId;
  final String Naziv;
  final String Opis;
  final double Cijena;
  final List<int>? Slika;

  Jelo({required this.JeloId,
      required this.Naziv,
      required this.Opis,
      required this.Cijena,
      required this.Slika});

  factory Jelo.fromJson(Map<String, dynamic> json) {
    return Jelo(
        JeloId: json["id"],
        Naziv: json['naziv'],
        Opis: json['opis'],
        Cijena: json['cijena'],
        Slika: json["slika"] != null
            ? base64.decode(json['slika'] as String)
            : null);
  }

  Map<String, dynamic> toJson() => {
        "Id": JeloId,
        "Naziv": Naziv,
        "Opis": Opis,
        "Cijena": Cijena,
        "Slika": Slika != null ? base64.encode(Slika!) : Slika,
      };
}
