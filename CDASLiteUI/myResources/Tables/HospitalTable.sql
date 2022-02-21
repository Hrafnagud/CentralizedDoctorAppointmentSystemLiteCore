INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(3, 'Adana A��z Ve Di� Sa�l��� Merkezi', '100.Y�l Mah. 85341 Sk No:2 �ukurova/adana', '3222563960', 'adana.adsm@saglik.gov.tr', '37.0024', '35.328876', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(2, 'Adana Ceyhan Devlet Hastanesi', 'Ceyhan Devlet Hastanesi, Ulus Mh., 01950 Ceyhan/adana', '3226131362', 'adanadhs1@saglik.gov.tr', '37.02709', '35.819077', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(15, 'Adana Devlet Hastanesi', 'Adana Devlet Hastanesi H.�mer Sabanc� Cd. (Eski Numune Hastanesi) 01140 Seyhan Adana\nSemt Poliklini�i Eski Adana Devlet Hastanesi Karata� Yolu �zeri 01160 Y�re�ir Adana\n\n', '3223215752', 'adanadhs11@saglik.gov.tr', '36.985157', '35.33731', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(3, 'Adana Dr.Ekrem Tok Ruh Sa�l��� Ve Hastal�klar� Hastanesi', 'Belediye Evleri Mahallesi Turgut �zal Bulvar�  No : 230  Kurttepe /  �ukurova /adana pk-01330', '3222390475', 'adanarshh1@saglik.gov.tr', '37.055656', '35.275986', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(12, 'Adana Kad�n Do�um Ve �ocuk Hastal�klar� Hastanesi', 'Ana Bina:bak�myurdu Cad. No:145  Seyhan/adana   Tel:0322 3654950\nEk Bina: Erdal Acet Cad. D��eme Mah. Marsa Ya� Fabrikas� Kar��s� Seyhan/adana  Tel:0322 4316001', '3224316001', 'adanadcb1@saglik.gov.tr', '36.842556', '34.623135', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(6, 'Adana Karaisal� Devlet Hastanesi', 'Karaisal� Devlet Hastanesi', '3225512524', 'adanadhs@hotmail.com', '37.254704', '35.060955', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(8, 'Adana Kozan Devlet Hastanesi', 'Kozan Devlet Hastanesi', '3225159999', 'kozan@kozan.gov.tr', '37.464188', '35.825237', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(15, 'Adana Numune E�itim Ve Ara�t�rma  Hastanesi', 'Serinevler Mah. Ege Ba�tur Bulvar� �zeri  Y�re�ir / Adana', '3223550101', 'adanaeah1@saglik.gov.tr', '37.019722', '35.321625', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(9, 'Adana Pozant� 80.Y�l Devlet Hastanesi', 'E90 Eski Ankara Yolu �zeri Karayolu Pozant�/adana', '3225813945', 'adanadhs5@saglik.gov.tr', '37.460636', '34.87344', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(13, 'Adana Tufanbeyli Devlet Hastanesi', 'Cumhuriyet Mahallesi Hastane Caddesi\nTufanbeyli/adana', '3227819496', 'adanadhs9@saglik.gov.tr', '37.81643', '35.824677', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(12, 'Adana �ukurova Dr.A�k�m T�fek�i Devlet Hastanesi', 'Yeni Baraj Mah.Hac� �mer Sabanc� Cad.01330 Seyhan/adana', '3222259329', 'cukurovadh@hotmail.com', '37.02135', '35.319073', GETDATE() );
INSERT INTO Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES(5, 'Adana �mamo�lu Devlet Hastanesi', 'H�rriyet Mahlesi 700.Sokak', '3228913701', 'adanadhs2@saglik.gov.tr', '37.252346', '35.647568', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'AVCILAR'), '�stanbul -(Avrupa)-  Avc�lar Murat K�l�k Devlet Hastanesi', '�niversite Mahallesi Yeni Yuvam Sokak No:4 Avc�lar / �stanbul', '2124129000', 'avcilardh@saglik.gov.tr', '40.98', '28.73', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ATA�EH�R'), '�stanbul- (Anadolu)- Ata�ehir A��z Ve Di� Sa�l��� Merkezi', 'Ali Nihat Tarlan Caddesi Kartal Sokak No:11 ��erenk�y Ata�ehir', '2164697740', 'atasehiradsm@kadikoyagizdis.gov.tr', '40.966774', '29.105333', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ATA�EH�R'), '�stanbul- (Anadolu)- Ata�ehir- Fatih Sultan Mehmet E�itim Ara�t�rma Hastanesi', 'E-5 Karayolu �zeri ��erenk�y Ata�ehir/istanbul', '2165783000', 'fsm.saglikisleri@gmail.com', '40.970596', '29.104897', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BEYKOZ'), '�stanbul- (Anadolu)- Beykoz A��z Ve Di� Sa�l��� Merkezi', '�ubuklu Mh. Vatan Cd. No-26 �stanbul/beykoz', '2164250524', 'bilgi@beykozadsm.gov.tr', '41.09709', '29.091467', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BEYKOZ'), '�stanbul- (Anadolu)- Beykoz Devlet Hastanesi', 'Saip Molla Cad.K�sayol Sok. No:1 Beykozistanbul', '2163222210', 'istanbuldhs4@saglik.gov.tr', '41.117126', '29.08625', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SULTANBEYL�'), '�stanbul- (Anadolu)- Dervi� Ali -Hesna Ceylan A��z Ve Di� Sa�l��� Merkezi', 'Ahmet Yesevi Mah. M�cahit Cad. No : 48 Sultanbeyli / �stanbul', '2165924111', 'sultanbeyliadsm@gmail.com', '15.45', '15.45', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�SK�DAR'), '�stanbul- (Anadolu)- Dr.Siyami Ersek G���s Kalp Ve Damar Cerrahisi E�itim Ve Ara�t�rma Hastanesi', 'T�bbiye Cad No:13 Haydarpa�a �sk�dar �stanbul', '2165424444', 'istanbuleah20@saglik.gov.tr', '41.004288', '29.024698', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KADIK�Y'), '�stanbul- (Anadolu)- Kad�k�y- Erenk�y Fizik Tedavi Ve Rehabilitasyon Hastanesi', '�emsettin G�naltay Cad./sultan sok. no:14, erenk�y/istanbul', '2164118011', 'istanbulfth1@saglik.gov.tr', '40.978344', '29.084217', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KADIK�Y'), '�stanbul- (Anadolu)- Kad�k�y- Erenk�y Ruh Ve Sinir Hastal�klar� E�itim Ve Ara�t�rma Hastanesi', '19 mAy�s Mah.Sinanercan Cad.No:29 Kazasker/kad�k�y/istanbul ', '2163609164', 'gknecla@gmail.com', '40.980675', '29.0914', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KADIK�Y'), '�stanbul- (Anadolu)- Kad�k�y- G�ztepe A��z Ve Di� Sa�l��� Merkezi', 'Fahrettin Kerim G�kay Cad. No:161/8 G�ztepe Kad�k�y/istanbul', '2165659191', 'bilgi-islem@goztepeagizdis.gov.tr', '29.03', '40.59', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KARTAL'), '�stanbul- (Anadolu)- Kartal A��z Ve Di� Sa�l��� Merkezi', 'Barbaros Hayrettin Pa�a Cad. Orta Mah. No: 66 So�anl�k-kartal / �stanbul P.K.:34888', '2165863500', 'kartaladsm@gmail.com', '40.983074', '29.221058', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KARTAL'), '�stanbul- (Anadolu)- Kartal- Dr.L�tfi K�rdar E�itim Ve Ara�t�rma Hastanesi', 'E-5 Karayolu Mevkii �emsi Denizer Cad. 34865', '2164413900', 'istanbuleah17@sbkeah.gov.tr', '40.91948', '29.171963', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KARTAL'), '�stanbul- (Anadolu)- Kartal- Ko�uyolu Y�ksek �htisas E�itim Ve Ara�t�rma Hastanesi', 'Cevizli Kav�a�� Denizer Caddesi No 2 Kartal, �stanbul', '2165001500', 'kosuyolu@kosuyolu.gov.tr', '40.911827', '29.155483', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KARTAL'), '�stanbul- (Anadolu)- Kartal- Yakac�k Do�um Ve �ocuk Hastal�klar� Hastanesi', '�ar�� Mah. So�anl�k Cad. No:17 - Yakac�k / Kartal - �stanbul', '2163772396', 'yakacikposta@gmail.com', '40.921036', '29.2202', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KARTAL'), '�stanbul- (Anadolu)- Kartal- Yavuz Selim  Devlet Hastanesi', '�stasyon Cad. Do�an Sok. No:11 Kartal/istanbul', '2163066850', 'istanbuldhs11@saglik.gov.tr', '40.891846', '29.182262', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'MALTEPE'), '�stanbul- (Anadolu)- Maltepe Devlet Hastanesi', 'Altay�e�me Mah. �am Sok. No:26-28 34843 Maltepe / �stanbul', '2164597770', 'info@maltepedevlethastanesi.gov.tr', '40.937267', '29.135023', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'MALTEPE'), '�stanbul- (Anadolu)- Meslek Hastal�klar� Hastanesi', 'Ba��b�y�k Mahallesi Atat�rk Caddesi Ba��b�y�k/maltepe - �stanbul', '2164214400', 'info@imhh.gov.tr', '40.952938', '29.139519', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'PEND�K'), '�stanbul- (Anadolu)- Pendik Devlet Hastanesi', 'Bat� Mahallesi Dr.Orhan Maltepe Cd. N:17 Pendik �stanbul', '2164912937', 'mhrs@pendikdevlethastanesi.gov.tr', '40.877438', '29.229256', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SANCAKTEPE'), '�stanbul- (Anadolu)- Sancaktepe A��z Ve Di� Sa�l��� Merkezi', 'Ey�p Sultan Mahallesi, M�minler Cad. No:1 Sancaktepe - �stanbul', '2165863600', 'info@sancaktepeadsm.gov.tr', '41.007885', '29.217924', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'MALTEPE'), '�stanbul- (Anadolu)- S�reyyapa�a G���s Hastal�klar� Ve G���s Cerrahisi E�itim Ve Ara�t�rma Hastanesi', 'Ba��b�y�k Mah. Maltepe �stanbul', '2164214200', 'info@sureyyapasa.gov.tr', '40.953976', '29.14072', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'PEND�K'), '�stanbul- (Anadolu)- T.C.Sa�l�k Bakanl���-marmara �niversitesi Pendik E�itim Ve Ara�t�rma Hastanesi', 'Mimar Sinan Cad. No:41 �st Kaynarca Fevzi �akmak Mah. Pendik/istanbul', '2166254545', 'mhrs.marmara@marmaraeah.gov.tr', '40.979122', '29.055748', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SULTANBEYL�'), '�stanbul- (Anadolu)- Tacirler E�itim Vakf� Sultanbeyli Devlet Hastanesi', ' Mehmet Akif Ersoy Mah. Cami Cad. No:3 Sultanbeyli-istanbul', '2165642400', 'info@sultanbeylidevlethast.gov.tr', '40.96606', '29.26584', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'TUZLA'), '�stanbul- (Anadolu)- Tuzla Devlet Hastanesi', '��meler Mah. Enise Sok No:5 Tuzla / �st', '2164940952', 'istanbuldhs19@saglik.gov.tr', '29.18', '40.5', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�EKMEK�Y'), '�stanbul- (Anadolu)- �ekmek�y A��z Ve Di� Sa�l��� Merkezi', 'So�ukp�nar Mah.Ihlamur Cad.No:40 �ekmek�y-ta�delen/istanbul', '2163126077', 'cekmekoyadsm@gmail.com', '29.23', '41.022', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�MRAN�YE'), '�stanbul- (Anadolu)- �mraniye E�itim Ve Ara�t�rma Hastanesi', 'Elmal� Kent Mh Adem Yavuz Cd No:1  �mraniye/istanbul', '2166321818', 'bilgi@ueh.gov.tr', '41.032654', '29.039206', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�SK�DAR'), '�stanbul- (Anadolu)- �sk�dar Devlet Hastanesi', 'Barbaros Mahallesi Veysipa�a Sokak No:14 Ko�uyolu �sk�dar �stanbul(Anabina (Eski Polis Hastanesi)) Kalfa�e�me Sokak No:1 Ko�uyolu �sk�dar �stanbul (Valideba�(Eski ��retmenler Hastanesi)) Halk Caddesi Sunar �� Han� No:37 �sk�dar �stanbul (Do�anc�lar Semt Poliklini�i)', '2164747900', 'info@uskudarhastanesi.gov.tr', '41.025497', '29.037498', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�SK�DAR'), '�stanbul- (Anadolu)- �sk�dar- Haydarpa�a Numune E�itim Ve Ara�t�rma Hastanesi', 'T�bb�ye Cad.No:40 �sk�dar/istanbul', '2165423232', 'hnhmhrs@gmail.com', '41.009308', '29.02259', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�SK�DAR'), '�stanbul- (Anadolu)- �sk�dar- Zeynep Kamil Kad�n Ve �ocuk Hastal�klar� E�itim Ve Ara�t�rma Hastanesi', 'Zeynep Kamil Mahallesi, Dr.Burhanettin �st�nel Sokak, No:3-4 34668 �sk�dar-istanbul', '2163910680', 'info@zeynepkamil.gov.tr', '41.014874', '29.026888', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '��LE'), '�stanbul- (Anadolu)- �ile Devlet Hastanesi', 'Atat�rk Cad Balibey Mah.No :1 �ile/istanbul', '2167120999', 'silehastane@gmail.com', '29.616653', '41.17459', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ARNAVUTK�Y'), '�stanbul- (Avrupa)- Arnavutk�y Devlet Hastanesi', 'Merkez Mahallesi  Fatih Caddesi No:3 Arnavutk�y / �stanbul  ', '2124531212', 'istanbuldhs33@saglik.gov.tr', '28.747116', '41.17765', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'AVCILAR'), '�stanbul- (Avrupa)- Avc�lar A��z Ve Di� Sa�l��� Merkezi', 'Kirazl� Cad. G�kler Sokak No:60/2 Avc�lar /istanbul', '2124200808', 'avcilaradsm@gmail.com', '28.716389', '40.981915', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAH�EL�EVLER'), '�stanbul- (Avrupa)- Bah�elievler A��z Ve Di� Sa�l��� Merkezi', 'Adnan Kahveci Bulvar� Eski Londra Asfalt� No:141/2 Bah�elievler/ist', '2124415312', 'mhrs@bahcelievleragizdis.gov.tr', '40.99959', '28.855564', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAH�EL�EVLER'), '�stanbul- (Avrupa)- Bah�elievler Devlet Hastanesi', 'Bah�elievler', '2124967000', 'fatihhrzcu@gmail.com', '15.45', '15.45', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAH�EL�EVLER'), '�stanbul- (Avrupa)- Bah�elievler- Fizik Tedavi Ve Rehabilitasyon E�itim Ve Ara�t�rma Hastanesi', 'Kocasinan Merkez Mahallesi Karadeniz Caddesi No:48 Bah�elievler �stanbul 34192', '2124422200', 'bilgi@istanbulftr.gov.tr', '28.84444', '41.006382', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAKIRK�Y'), '�stanbul- (Avrupa)- Bak�rk�y -Lepra Deri Ve Z�hrevi Hastal�klar� Hastanesi', 'Zuhuratbaba Mah.Tevfik Sa�lam Caddesi No:26/4 Ak�l Hastanesi Arkas� Bak�rk�y - �stanbul', '2125701026', 'lepraderi@gmail.com', '40.989532', '28.858418', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAKIRK�Y'), '�stanbul- (Avrupa)- Bak�rk�y Prof.Dr.Mazhar Osman Ruh Sa�. Ve Sinir Hast.  E�t. Ve Ara�. Hastanesi', 'Zuhratbaba Mah Dr. Teyfik Sa�lam Cad No : 25/2  Sa�l�k Bakanl��� T�rkiye Kamu Hastaneleri Kurumu  �stanbul Bak�rk�y B�lgesi Kamu Hastaneleri Birli�i Genel Sekreterli�i Bak�rk�y Prof. Dr. Mazhar Osman Ruh Sa�l��� Ve Sinir Hastal�klar� E�itim Ve Ara�t�rma Hastanesi ', '2124091515', 'istanbuleah5@saglik.gov.tr', '40.990654', '28.860542', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAKIRK�Y'), '�stanbul- (Avrupa)- Bak�rk�y- Deri Ve Tenas�l Hastal�klar� Hastanesi', 'Zuhuratbaba Mahallesi, Doktor Tevfik Sa�lam Caddesi, No.26 Bak�rk�y - �stanbul ', '2125728293', 'istanbuldzh1@saglik.gov.tr', '41.009308', '28.985683', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAKIRK�Y'), '�stanbul- (Avrupa)- Bak�rk�y- Dr.Sadi Konuk E�itim Ara�t�rma Hastanesi', 'Tevfik Sa�lam Cad. No:11 Zuhuratbaba �stanbul 34147 T�rkiye ', '2124147171', 'bilgi@beah.gov.tr', '40.993954', '28.865831', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAYRAMPA�A'), '�stanbul- (Avrupa)- Bayrampa�a Devlet Hastanesi', '�smetpa�a Mah. Kenar Sok. No:22 Bayrampa�a - �stanbul', '2125676774', 'bdhpersonel@gmail.com', '41.04188', '28.903076', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BA�CILAR'), '�stanbul- (Avrupa)- Ba�c�lar E�itim Ve Ara�t�rma Hastanesi', 'Merkez Mahallesi Mimar Sinan Caddesi 6. Sokak  Ba�c�lar / �stanbul ', '2124404000', ' info@beh.gov.tr', '41.0311', '28.870243', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BA�AK�EH�R'), '�stanbul- (Avrupa)- Ba�ak�ehir Devlet Hastanesi', 'Ba�ak�ehir 4.Etap Yunus Emre Caddesi �ett Son Durak  Ba�ak�ehir Devlet Hastanesi', '2124880170', 'personel@saglik.gov.tr', '41.055798', '28.801834', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BE��KTA�'), '�stanbul- (Avrupa)- Be�ikta�- Sait �ift�i Devlet Hastanesi', 'Barbaros Bulvar� No:109 Be�ikta�-istanbul', '2123816700', 'bscdh.mhrs@gmail.com', '15.45', '15.45', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'B�Y�K�EKMECE'), '�stanbul- (Avrupa)- B�y�k�ekmece Devlet Hastanesi', '1)Sahil(Acil) Binas�: Atat�rk Mah. Mustafa K. Pa�a Cad. H�lya Ko�yi�it Sok No: 1 B�y�k�ekmece - �stanbul 2)G�rp�nar (Ek) Poliklinik Binas�: P�nartepe Mah. Belediye Cad.5/a daire 1 b�y�k�ekmece istanbul (eski g�rp�nar belediye binas�) 3)eski ssk binas�-dizdariye mah. g�lboyu cad.b�y�k�ekmece/istanbul', '2128821680', 'bilgiislem@buyukcekmecedh.gov.tr', '41.01297', '28.598675', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'S�L�VR�'), '�stanbul- (Avrupa)- Dr.Necmi Ayano�lu Silivri Devlet Hastanesi', 'Yeni Mahalle Efrahim �zt�rk Sokak No:1 Silivri/istanbul', '2127272100', 'bilgiislem@silivridh.gov.tr', '41.078186', '28.250095', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ESENLER'), '�stanbul- (Avrupa)- Esenler Kad�n Do�um Ve �ocuk Hastal�klar� Hastanesi', 'Havaalan� Mah.Ta�oca�� Cad.No 19 34220 Esenler/istanbul', '2126291308', 'esenlerkdch@gmail.com', '41', '28', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ESENYURT'), '�stanbul- (Avrupa)- Esenyurt Devlet Hastanesi', 'Fatih Mahallesi 19 May�s Bulvar� No:8 Esenyurt/istanbul', '2125961999', 'esenyurtdevlethastanesi@gmail.com', '41.04259', '28.666656', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'EY�P'), '�stanbul- (Avrupa)- Ey�p Devlet Hastanesi', 'Silahtara�a Caddesi No: 535557', '2124172900', 'istanbuldhs7@saglik.gov.tr', '41.0572', '28.941015', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'FAT�H'), '�stanbul- (Avrupa)- Fatih- �stanbul E�itim Ve Ara�t�rma Hastanesi', 'Kasap �lyas Mah. Org. Abdurrahman Nafiz G�rman Cd. Pk: 34098  Fatih-istanbul', '2125884400', 'iletisim@istanbuleah.gov.tr', '41.008663', '28.938332', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'FAT�H'), '�stanbul- (Avrupa)- Fatih-haseki E�itim Ve Ara�t�rma Hastanesi', 'Millet Cd. Aksaray / Fatih -�stanbul  ', '2125294400', 'hasekikalite@hasekihastanesi.gov.tr ', '41.010185', '28.94434', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'GAZ�OSMANPA�A'), '�stanbul- (Avrupa)- Gaziosmanpa�a Taksim E�itim Ve Ara�t�rma Hastanesi', 'Karayollar� Mahallesi 616. Sokak Gaziosmanpa�a �stanbul', '2122524300', 'a@a.com', '41.036118', '28.983307', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'G�NG�REN'), '�stanbul- (Avrupa)- G�ng�ren A��z Ve Di� Sa�l��� Merkezi', 'Merkez Mahallesi �nl� Sokak No:6 K�yi�i-g�ng�ren/ �stanbul ', '2125563636', 'mhrsgungoren@gmail.com', '41.002056', '28.85402', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KA�ITHANE'), '�stanbul- (Avrupa)- Ka��thane Devlet Hastanesi', 'Sanayi Mah. �ahinler Sk. No:23 P.K.: 34416 Ka��thane/istanbul', '2122802222', 'hasan_muti_53@hotmail.com', '29.00144', '41.092194', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KA�ITHANE'), '�stanbul- (Avrupa)- Ka��thane- �l �zel �daresi A��z Ve Di� Hastal�klar� Hastanesi', 'Dar�laceze Cad. G�rsel Mahallesi Ka��thane / �stanbul', '2123201043', 'istanbuldis1@saglik.gov.tr', '41.067123', '28.974466', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'K���K�EKMECE'), '�stanbul- (Avrupa)- K���k�ekmece- Kanuni Sultan S�leyman E�itim Ve Ara�t�rma Hastanesi', 'Alt�n�ehir, Turgut �zal Cd. No:1 34303 Halkal� / K���k�ekmece / �stanbul', '2124041500', 'mhrs@kanunieah.gov.tr', '41.055553', '28.75989', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'K���K�EKMECE'), '�stanbul- (Avrupa)- Mehmet Akif Ersoy G���s Kalp Ve Damar Cerrahisi E�itim Ve Ara�t�rma Hastanesi', '�stasyon Mah.Turgut �zal Bulvar� No:11 K���k�ekmece- �stanbul', '2126922000', 'info@imaeh.gov.tr', '41.02194', '28.771322', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BEYO�LU'), '�stanbul- (Avrupa)- Prof.Dr.N.Re�at Belger Beyo�lu G�z E�itim Ve Ara�t�rma Hastanesi', 'Bereketzade Cami Sokak No:2 Beyo�lu/istanbul (Galata Kulesinin 50 M Asagisinda)', '2122515900', 'emreyilmaz@beyoglugoz.gov.tr', '41.028866', '28.973694', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SARIYER'), '�stanbul- (Avrupa)- Sar�yer- Metin Sabanc� Baltaliman� Kemik Hastal�klar� E�itim Ara�t�rma Hastanesi', 'Rumelihisar� Cad.No:62 Baltaliman� Sar�yer �stanbul', '2123237075', 'info@baltalimani.gov.tr', '41.097076', '29.05341', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SARIYER'), '�stanbul- (Avrupa)- Sar�yer- �smail Akg�n Devlet Hastanesi', 'Dursun Fakih Sok. No:1 Sar�yer-istanbul', '2122420665', 'istanbuldhs13@saglik.gov.tr', '41.17245', '29.056778', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SARIYER'), '�stanbul- (Avrupa)- Sar�yer- �stinye Devlet Hastanesi', '�stinye Caddesi No:98 34465 �stinye - Sar�yer - �stanbul', '2123234444', 'bim@idh.gov.tr', '41.119194', '29.057293', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'SULTANGAZ�'), '�stanbul- (Avrupa)- Sultangazi- L�tfiye Nuri Burat Devlet Hastanesi', 'L�tfiye Nuri Burat Devlet Hastanesi 50.Y�l Mah. 2106 Sokak No:8 Sultangazi / �stanbul ', '2125941253', 'istanbuldhs8@saglik.gov.tr', '41.096752', '28.867178', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ZEYT�NBURNU'), '�stanbul- (Avrupa)- S�leymaniye Kad�n Do�um Ve �ocuk Hastal�klar� E�itim Ve Ara�t�rma Hastanesi', 'Telsiz Mah. Bal�kl� Kazl��e�me Yolu No:1 Zeytinburnu / �stanbul ', '2124986161', 'istanbuleah8@saglik.gov.tr', '40.999077', '28.914127', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'BAYRAMPA�A'), '�stanbul- (Avrupa)- Top�ular A��z Ve Di� Sa�l��� Merkezi', 'Abdi �pek�i Caddesi Bayrampa�a Rami ', '2126169812', 'topcularadsm1@gmail.com', '1745', '1650', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'ZEYT�NBURNU'), '�stanbul- (Avrupa)- Yedikule G���s Hastal�klar� Ve G���s Cerrahisi E�itim Ve Ara�t�rma Hastanesi', 'Belgrad Kap� Yolu No:1 Zeytinburnu / ', '2126641700', 'bashekimlik@yedikulegogus.gov.tr', '41.00361', '28.920135', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '�ATALCA'), '�stanbul- (Avrupa)- �atalca- �lyas �okay Devlet Hastanesi', 'Ferhat Pa�a Mahallesi,�stanbul Caddesi �atalca/istanbul', '2127891792', 'catalcadh@gmail.com', '41.138977', '28.466751', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= '���L�'), '�stanbul- (Avrupa)- �i�li Etfal E�itim Ve Ara�t�rma Hastanesi', '19 mAy�s Mh., 34360 �i�li/istanbul  ', '2123735000', 'mhrs@sislietfal.gov.tr', '41.058044', '28.989956', GETDATE() );
INSERT INTO  Hospitals (DistrictId, HospitalName,Address,PhoneNumber,Email,Latitude,Longitude,CreatedDate) VALUES((select Id from Districts where DistrictName= 'KADIK�Y'), '�stanbul- (Anadolu)- S.B. �stanbul Medeniyet �niversitesi G�ztepe E�itim Ve Ara�t�rma Hastanesi', '�stanbul Medeniyet �niversitesi  G�ztepe E�itim Ve Ara�t�rma Hastanesi Prof. Fahrettin G�kay Cad. Kad�k�y / �stanbul', '2165664000', 'bilgi@sbgoztepehastanesi.gov.tr', '29.057781', '40.985794', GETDATE());