import 'dart:convert';

class Narudzba {
  final NarudzbaId;
  final DateTime DatumNarudzbe;
  final korisnikId;
  final statusNarudzbeId;

  Narudzba({required this.NarudzbaId, 
           required this.DatumNarudzbe, 
           required this.korisnikId, 
           required this.statusNarudzbeId});


  factory Narudzba.fromJson(Map<String, dynamic> json) {
    return Narudzba(
        NarudzbaId: ["id"],
        DatumNarudzbe: json['DatumNarudzbe'],
        korisnikId: ['KorisnikId'],
        statusNarudzbeId: ['StatusNarudzbeId'],
    );
  }
  Map<String, dynamic> toJson() => {
        "NarudzbaId": NarudzbaId,
        "DatumNarudzbe": DatumNarudzbe,
        "korisnikId": korisnikId,
        "statusNarudzbeId": statusNarudzbeId,
      };
}
