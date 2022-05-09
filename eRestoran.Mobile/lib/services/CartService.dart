import 'package:flutter/material.dart';
import 'package:restoran_seminarski/models/CartModel.dart';
import 'package:restoran_seminarski/models/Jelo.dart';

class CartService{
  static Map<String, CartModel> products= <String, CartModel>{};
  static int? NarudzbaId;
  static int Ukupno = 0;

  int? get ukupno{ return Ukupno; }
  int? get narudzbaId{ return NarudzbaId; }
  void set narudzbaId(int? value){ NarudzbaId = value; }

  static void removeProduct(String id){
    products.remove(id);
  }

  static void addProduct(Jelo jelo, int quantity){
    CartModel cm = CartModel();
    cm.proizvod = jelo;
    cm.kolicina = quantity;
    cm.NarudzbaId = NarudzbaId;
    Map<String, CartModel> map = {'${jelo.JeloId}': cm};
    if(!products.containsKey('${jelo.JeloId}')) {
        products.addAll(map);
        print(map['${jelo.JeloId}']!.proizvod.Naziv + '  '+ map['${jelo.JeloId}']!.kolicina.toString());
      }
    else{
      var cm=products['${jelo.JeloId}'];
      cm?.kolicina+=1;
      products.update('${jelo.JeloId}', (value) => cm!);
      print(cm?.kolicina);  
    }
    Ukupno += cm.proizvod.Cijena.round();
  }

  static void decreaseQuantity(Jelo jelo){
    var product = products['${jelo.JeloId}'];
    product?.kolicina-=1;
    products.update('${jelo.JeloId}', (value) => product!);
    Ukupno -= jelo.Cijena.round();
  }

  static void clear(){
    CartService.products.clear();
    CartService.NarudzbaId = null;
    CartService.Ukupno = 0;
  }
}