import 'dart:convert';
import 'dart:developer';
import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

import '../models/Korisnik.dart';

class APIService {
  static String? username;
  static String? password;
  static int? korisnikId;
  static const String baseRoute = "http://10.0.2.2:5001/api/";
  String? route;

  APIService({this.route});

  static Future<Korisnik?> prijava() async {
    String baseUrl = baseRoute + "Korisnik/Authenticate";

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      return Korisnik.fromJson(json.decode(response.body));
    }

    return null;
  }

  static Future<dynamic> GetById(String route, int id) async {
    String baseUrl = baseRoute + route + "/" + id.toString();

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );
    if (response.statusCode == 200) {
      return json.decode(response.body);
    }

    return null;
  }

  static Future<List<dynamic>?> Get(String route, dynamic? object) async {
    String queryString;
    String baseUrl = baseRoute + route;

    if (object != null) {
      if (object is int) {
        baseUrl = baseUrl + '/' + object.toString();
      } else {
        queryString = Uri(queryParameters: object).query;
        baseUrl = baseUrl + '?' + queryString;
      }
    }

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth});
    print('Status code [GET] -> ' + response.statusCode.toString());
    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }

  static Future<dynamic> post(String route, String body) async {
    String baseUrl = baseRoute + route;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.post(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    print('Status code [POST] -> ' + response.statusCode.toString());
    if (response.statusCode == 200) {
      return json.decode(response.body.toString());
    } else {
      return null;
    }
  }

  static Future<dynamic> put(String route, int id, String body) async {
    String baseUrl = baseRoute + route + "/" + id.toString();

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.put(
      Uri.parse(baseUrl),
      headers: {
        HttpHeaders.contentTypeHeader: 'application/json; charset=UTF-8',
        HttpHeaders.authorizationHeader: basicAuth
      },
      body: body,
    );

    print('Status code [PUT] -> ' + response.statusCode.toString());

    if (response.statusCode == 200) {
      return json.decode(response.body.toString());
    } else {
      return null;
    }
  }
}
