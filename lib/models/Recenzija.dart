import 'dart:convert';

class Recenzija {
     final  int Ocjena; 
     final String  Opis;
     final int JeloId ;

  Recenzija({required this.Ocjena, 
           required this.Opis, 
           required this.JeloId});


  factory Recenzija.fromJson(Map<String, dynamic> json) {
    return Recenzija(
        Ocjena: json["Ocjena"],
        Opis: json['Opis'],
        JeloId: json['JeloId'],
    );
  }

  Map<String, dynamic> toJson() => {
        "Ocjena": Ocjena,
        "Opis": Opis,
        "JeloId": JeloId,
      };
}
