import 'dart:convert';

class NarudzbaStavke {
  late int? Id;
  final int Kolicina;
  final int Cijena;
  final int JeloId;
  final int NarudzbaId;
  
  NarudzbaStavke({  this.Id, 
                  required this.Kolicina,
                  required this.Cijena,
                  required this.JeloId,
                  required this.NarudzbaId});


  factory NarudzbaStavke.fromJson(Map<String, dynamic> json) {
    return NarudzbaStavke(
        Id: json["Id"],
        Kolicina: json['Kolicina'],
        Cijena: json['Cijena'],
        JeloId: json['JeloId'],
        NarudzbaId: json['NarudzbaId'],
    );
  }
  Map<String, dynamic> toJson() => {
        "Id": Id,
        "Kolicina": Kolicina,
        "Cijena": Cijena,
        "JeloId": JeloId,
        "NarudzbaId": NarudzbaId,
      };
}
