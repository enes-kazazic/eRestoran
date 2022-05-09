import 'dart:convert';

class Narudzba {
  late int? NarudzbaId;
  final DateTime DatumNarudzbe;
  final korisnikId;
  final int statusNarudzbeId;
  final String? statusNarudzbe;

  Narudzba(
      {this.NarudzbaId,
      required this.DatumNarudzbe,
      required this.korisnikId,
      required this.statusNarudzbeId,
      this.statusNarudzbe});

  factory Narudzba.fromJson(Map<String, dynamic> json) {
    return Narudzba(
        NarudzbaId: json["id"],
        DatumNarudzbe: DateTime.parse(json['datumNarudzbe'].toString()),
        korisnikId: json['korisnikId'],
        statusNarudzbeId: json['statusNarudzbeId'],
        statusNarudzbe: json["statusNarudzbe"]);
  }
  Map<String, dynamic> toJson() => {
        "NarudzbaId": NarudzbaId,
        "DatumNarudzbe": DatumNarudzbe.toIso8601String(),
        "korisnikId": korisnikId,
        "statusNarudzbeId": statusNarudzbeId,
      };
}
