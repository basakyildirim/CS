--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.5
-- Dumped by pg_dump version 9.6.6

-- Started on 2017-12-11 23:17:26

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12355)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2202 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 181 (class 1259 OID 16395)
-- Name: Hastane; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Hastane" (
    hastane_adi character varying(2044) NOT NULL,
    kadro character varying(2044) NOT NULL,
    ilceid integer NOT NULL
);


ALTER TABLE "Hastane" OWNER TO postgres;

--
-- TOC entry 182 (class 1259 OID 16403)
-- Name: bolum; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE bolum (
    bolumadi character varying(2044) NOT NULL
);


ALTER TABLE bolum OWNER TO postgres;

--
-- TOC entry 183 (class 1259 OID 16411)
-- Name: kadro; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE kadro (
    kadroid character varying NOT NULL,
    tc character varying NOT NULL,
    ad character varying NOT NULL,
    soyad character varying NOT NULL,
    telno character varying NOT NULL,
    k_tur character varying NOT NULL,
    baslangict date NOT NULL,
    calisma_gunu integer
);


ALTER TABLE kadro OWNER TO postgres;

--
-- TOC entry 184 (class 1259 OID 16419)
-- Name: doktor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE doktor (
    doktorid character varying(2044) NOT NULL,
    rank character varying(2044) NOT NULL,
    bolum character varying(2044) NOT NULL
)
INHERITS (kadro);


ALTER TABLE doktor OWNER TO postgres;

--
-- TOC entry 191 (class 1259 OID 16522)
-- Name: doktorid; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE doktorid
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 24444
    CACHE 1
    CYCLE;


ALTER TABLE doktorid OWNER TO postgres;

--
-- TOC entry 185 (class 1259 OID 16429)
-- Name: ilce; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE ilce (
    ilceid integer NOT NULL,
    ilceadi character varying(2044) NOT NULL,
    sehirid integer NOT NULL
);


ALTER TABLE ilce OWNER TO postgres;

--
-- TOC entry 192 (class 1259 OID 16524)
-- Name: kadroid; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE kadroid
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 24444
    CACHE 1
    CYCLE;


ALTER TABLE kadroid OWNER TO postgres;

--
-- TOC entry 186 (class 1259 OID 16437)
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE person (
    personid character varying(2044) NOT NULL,
    tc character varying(2044) NOT NULL,
    ad character varying(2044) NOT NULL,
    soyad character varying(2044) NOT NULL,
    cinsiyet character varying(2044) NOT NULL,
    e_posta character varying(2044) NOT NULL,
    sifre character varying(2044) NOT NULL,
    dogumt date,
    yetki integer
);


ALTER TABLE person OWNER TO postgres;

--
-- TOC entry 187 (class 1259 OID 16447)
-- Name: randevu; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE randevu (
    personid character varying NOT NULL,
    tc character varying(2044) NOT NULL,
    ad character varying(2044) NOT NULL,
    soyad character varying(2044) NOT NULL,
    dogumt date NOT NULL,
    cinsiyet character varying(2044) NOT NULL,
    e_posta character varying(2044) NOT NULL,
    randevuid character varying(2044) NOT NULL,
    randevut date NOT NULL,
    doktorid character varying(2044) NOT NULL,
    telno character varying(2044) NOT NULL
);


ALTER TABLE randevu OWNER TO postgres;

--
-- TOC entry 193 (class 1259 OID 16526)
-- Name: randevuid; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE randevuid
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 19999
    CACHE 1
    CYCLE;


ALTER TABLE randevuid OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 16455)
-- Name: sehir; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE sehir (
    sehirid integer NOT NULL,
    sehiradi character varying(2044) NOT NULL,
    ulkeid integer NOT NULL
);


ALTER TABLE sehir OWNER TO postgres;

--
-- TOC entry 194 (class 1259 OID 16529)
-- Name: serial; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE serial
    START WITH 1
    INCREMENT BY 1
    MINVALUE 0
    MAXVALUE 1
    CACHE 1
    CYCLE;


ALTER TABLE serial OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 16463)
-- Name: ulke; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE ulke (
    ulkeid integer NOT NULL,
    ulkeadi character varying(2044) NOT NULL
);


ALTER TABLE ulke OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 16471)
-- Name: yonetim; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE yonetim (
    kadroid character varying(2044) NOT NULL,
    kadro_title character(20) NOT NULL
);


ALTER TABLE yonetim OWNER TO postgres;

--
-- TOC entry 2181 (class 0 OID 16395)
-- Dependencies: 181
-- Data for Name: Hastane; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Hastane" (hastane_adi, kadro, ilceid) FROM stdin;
\.


--
-- TOC entry 2182 (class 0 OID 16403)
-- Dependencies: 182
-- Data for Name: bolum; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY bolum (bolumadi) FROM stdin;
Kulak Burun Bogaz
Dermotoloji
Gögüs Cerrahi
Radyoloji
Uroloji
Göz
\.


--
-- TOC entry 2184 (class 0 OID 16419)
-- Dependencies: 184
-- Data for Name: doktor; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY doktor (kadroid, tc, ad, soyad, telno, k_tur, baslangict, calisma_gunu, doktorid, rank, bolum) FROM stdin;
9	1234	hasan	akyürek	05366565566	2	2010-12-09	5	1	Yardımcı Docent	Kulak Burun Bogaz
10	1555	begüm	solmaz	05369999999	3	2011-12-10	4	2	Doçent	Göz
\.


--
-- TOC entry 2203 (class 0 OID 0)
-- Dependencies: 191
-- Name: doktorid; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('doktorid', 1, false);


--
-- TOC entry 2185 (class 0 OID 16429)
-- Dependencies: 185
-- Data for Name: ilce; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY ilce (ilceid, ilceadi, sehirid) FROM stdin;
\.


--
-- TOC entry 2183 (class 0 OID 16411)
-- Dependencies: 183
-- Data for Name: kadro; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY kadro (kadroid, tc, ad, soyad, telno, k_tur, baslangict, calisma_gunu) FROM stdin;
\.


--
-- TOC entry 2204 (class 0 OID 0)
-- Dependencies: 192
-- Name: kadroid; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('kadroid', 1, false);


--
-- TOC entry 2186 (class 0 OID 16437)
-- Dependencies: 186
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY person (personid, tc, ad, soyad, cinsiyet, e_posta, sifre, dogumt, yetki) FROM stdin;
1	1	1	c	Erkek	c	c	2017-12-11	0
12	65770022560	basak	yıldırım	Kadın	b@gmail.com	123	1997-02-11	0
13	151515	yasemin	çerci	Kadın	y@gmail.com	123	1995-01-10	0
0	12	levo	sen	Erkek	levo@gmail.com	1	2017-10-04	0
\.


--
-- TOC entry 2187 (class 0 OID 16447)
-- Dependencies: 187
-- Data for Name: randevu; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY randevu (personid, tc, ad, soyad, dogumt, cinsiyet, e_posta, randevuid, randevut, doktorid, telno) FROM stdin;
0	12	levo	sen	2017-10-04	Erkek	levo@gmail.com	1	2017-12-11	1	0522222222
1	1	1	c	2017-12-11	Erkek	c	2	2017-12-11	1	055
\.


--
-- TOC entry 2205 (class 0 OID 0)
-- Dependencies: 193
-- Name: randevuid; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('randevuid', 2, true);


--
-- TOC entry 2188 (class 0 OID 16455)
-- Dependencies: 188
-- Data for Name: sehir; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY sehir (sehirid, sehiradi, ulkeid) FROM stdin;
\.


--
-- TOC entry 2206 (class 0 OID 0)
-- Dependencies: 194
-- Name: serial; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('serial', 1, true);


--
-- TOC entry 2189 (class 0 OID 16463)
-- Dependencies: 189
-- Data for Name: ulke; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY ulke (ulkeid, ulkeadi) FROM stdin;
\.


--
-- TOC entry 2190 (class 0 OID 16471)
-- Dependencies: 190
-- Data for Name: yonetim; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY yonetim (kadroid, kadro_title) FROM stdin;
12	mudur yardımcı      
\.


--
-- TOC entry 2034 (class 2606 OID 16402)
-- Name: Hastane Hastane_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Hastane"
    ADD CONSTRAINT "Hastane_pkey" PRIMARY KEY (hastane_adi);


--
-- TOC entry 2038 (class 2606 OID 16410)
-- Name: bolum bolum_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bolum
    ADD CONSTRAINT bolum_pkey PRIMARY KEY (bolumadi);


--
-- TOC entry 2042 (class 2606 OID 16426)
-- Name: doktor doktor_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY doktor
    ADD CONSTRAINT doktor_pkey PRIMARY KEY (doktorid);


--
-- TOC entry 2047 (class 2606 OID 16436)
-- Name: ilce ilce_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY ilce
    ADD CONSTRAINT ilce_pkey PRIMARY KEY (ilceid);


--
-- TOC entry 2040 (class 2606 OID 16418)
-- Name: kadro kadro_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY kadro
    ADD CONSTRAINT kadro_pkey PRIMARY KEY (kadroid);


--
-- TOC entry 2049 (class 2606 OID 16444)
-- Name: person person_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY person
    ADD CONSTRAINT person_pkey PRIMARY KEY (personid, tc);


--
-- TOC entry 2060 (class 2606 OID 16478)
-- Name: yonetim pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY yonetim
    ADD CONSTRAINT pk PRIMARY KEY (kadroid);


--
-- TOC entry 2056 (class 2606 OID 16462)
-- Name: sehir sehir_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY sehir
    ADD CONSTRAINT sehir_pkey PRIMARY KEY (sehirid);


--
-- TOC entry 2044 (class 2606 OID 16428)
-- Name: doktor tcc; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY doktor
    ADD CONSTRAINT tcc UNIQUE (tc);


--
-- TOC entry 2058 (class 2606 OID 16470)
-- Name: ulke ulke_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY ulke
    ADD CONSTRAINT ulke_pkey PRIMARY KEY (ulkeid);


--
-- TOC entry 2051 (class 2606 OID 16515)
-- Name: person un; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY person
    ADD CONSTRAINT un UNIQUE (personid);


--
-- TOC entry 2052 (class 1259 OID 16484)
-- Name: fki_fk1; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk1 ON randevu USING btree (doktorid);


--
-- TOC entry 2035 (class 1259 OID 16490)
-- Name: fki_fk2; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk2 ON "Hastane" USING btree (ilceid);


--
-- TOC entry 2036 (class 1259 OID 16496)
-- Name: fki_fk3; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk3 ON "Hastane" USING btree (kadro);


--
-- TOC entry 2045 (class 1259 OID 16507)
-- Name: fki_fk4; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk4 ON ilce USING btree (sehirid);


--
-- TOC entry 2054 (class 1259 OID 16513)
-- Name: fki_fk5; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk5 ON sehir USING btree (ulkeid);


--
-- TOC entry 2053 (class 1259 OID 16521)
-- Name: fki_fk9; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_fk9 ON randevu USING btree (personid);


--
-- TOC entry 2064 (class 2606 OID 16479)
-- Name: randevu fk1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY randevu
    ADD CONSTRAINT fk1 FOREIGN KEY (doktorid) REFERENCES doktor(doktorid);


--
-- TOC entry 2061 (class 2606 OID 16485)
-- Name: Hastane fk2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Hastane"
    ADD CONSTRAINT fk2 FOREIGN KEY (ilceid) REFERENCES ilce(ilceid);


--
-- TOC entry 2062 (class 2606 OID 16491)
-- Name: Hastane fk3; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Hastane"
    ADD CONSTRAINT fk3 FOREIGN KEY (kadro) REFERENCES kadro(kadroid);


--
-- TOC entry 2063 (class 2606 OID 16502)
-- Name: ilce fk4; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY ilce
    ADD CONSTRAINT fk4 FOREIGN KEY (sehirid) REFERENCES sehir(sehirid);


--
-- TOC entry 2066 (class 2606 OID 16508)
-- Name: sehir fk5; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY sehir
    ADD CONSTRAINT fk5 FOREIGN KEY (ulkeid) REFERENCES ulke(ulkeid);


--
-- TOC entry 2065 (class 2606 OID 16516)
-- Name: randevu fk9; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY randevu
    ADD CONSTRAINT fk9 FOREIGN KEY (personid) REFERENCES person(personid);


--
-- TOC entry 2201 (class 0 OID 0)
-- Dependencies: 6
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2017-12-11 23:17:26

--
-- PostgreSQL database dump complete
--

