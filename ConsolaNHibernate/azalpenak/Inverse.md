🔴 A — .Inverse() gabe:



NHibernatek bi aldeak uste du harremanaren jabe direla (Erabiltzailea eta Eskaria).



SQL exekuzioa:



-- 1. Erabiltzailea sartzen du

INSERT INTO erabiltzaileak (izena) VALUES ('Ander');



-- 2. Eskariak sartzen ditu, baina erabiltzailea\_id oraindik ez du ezagutzen (null)

INSERT INTO eskariak (produktua, erabiltzailea\_id) VALUES ('Kafe-makina', NULL);

INSERT INTO eskariak (produktua, erabiltzailea\_id) VALUES ('Irratia', NULL);



-- 3. Orain NHibernate konturatzen da: harremana jarri behar du

UPDATE eskariak SET erabiltzailea\_id = 1 WHERE id = 1;

UPDATE eskariak SET erabiltzailea\_id = 1 WHERE id = 2;





🧱 2 INSERT + 2 UPDATE → 4 query guztira



🎯 Ez da efizientea, eta momentu batean NULL balioa sartzen du, beraz posible da constraint error ere sortzea (adibidez, erabiltzailea\_id ezin bada null izan).



🟢 B — .Inverse() jarrita:



NHibernatek badaki Eskaria dela erlazioaren jabea.

Beraz ez du UPDATErik behar.



SQL exekuzioa:



-- 1. Erabiltzailea

INSERT INTO erabiltzaileak (izena) VALUES ('Ander');



-- 2. Eskariak erabiltzailea\_id zuzenean ezarriz

INSERT INTO eskariak (produktua, erabiltzailea\_id) VALUES ('Kafe-makina', 1);

INSERT INTO eskariak (produktua, erabiltzailea\_id) VALUES ('Irratia', 1);





✅ 3 query soilik → garbiagoa, azkarragoa eta DB-n koherentea.



🧮 5️⃣ Laburpena

Egoera	SQL komandoak	Deskribapena

.Inverse() gabe	1 INSERT (erab) + 2 INSERT + 2 UPDATE = 5 query	NHibernatek bi aldeetatik kudeatu nahi du erlazioa

.Inverse() jarrita	1 INSERT (erab) + 2 INSERT = 3 query	Eskariak dira harremanaren jabeak, ez da UPDATErik behar

