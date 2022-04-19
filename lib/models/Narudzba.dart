import 'dart:convert';

class Narudzba {
  late int? NarudzbaId;
  final DateTime DatumNarudzbe;
  final korisnikId;
  final statusNarudzbeId;

  Narudzba({this.NarudzbaId, 
           required this.DatumNarudzbe, 
           required this.korisnikId, 
           required this.statusNarudzbeId});


  factory Narudzba.fromJson(Map<String, dynamic> json) {
    return Narudzba(
        NarudzbaId: json["id"],
        DatumNarudzbe: DateTime.parse(json['DatumNarudzbe'].toString()),
        korisnikId: ['KorisnikId'],
        statusNarudzbeId: ['StatusNarudzbeId'],
    );
  }
  Map<String, dynamic> toJson() => {
        "NarudzbaId": NarudzbaId,
        "DatumNarudzbe": DatumNarudzbe.toIso8601String(),
        "korisnikId": korisnikId,
        "statusNarudzbeId": statusNarudzbeId,
      };
}
