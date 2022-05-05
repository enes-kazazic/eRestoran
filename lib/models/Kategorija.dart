class Kategorija{
  late int KategorijaId;
  late String naziv;

  Kategorija({
    required this.KategorijaId,
    required this.naziv,
  });

  factory Kategorija.fromJson(Map<String, dynamic> json){
    return Kategorija(
        KategorijaId:json["id"],
        naziv: json["naziv"],
    );
  }
}