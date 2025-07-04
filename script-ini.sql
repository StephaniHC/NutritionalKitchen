--
-- PostgreSQL database dump
--

-- Dumped from database version 10.11
-- Dumped by pg_dump version 10.11

-- Started on 2025-07-04 00:46:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 6 (class 2615 OID 93762)
-- Name: outbox; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA outbox;


ALTER SCHEMA outbox OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 200 (class 1259 OID 93779)
-- Name: outboxMessage; Type: TABLE; Schema: outbox; Owner: postgres
--

CREATE TABLE outbox."outboxMessage" (
    "outboxId" uuid NOT NULL,
    content text,
    type text NOT NULL,
    created timestamp with time zone NOT NULL,
    processed boolean NOT NULL,
    "processedOn" timestamp with time zone,
    "correlationId" text,
    "traceId" text,
    "spanId" text
);


ALTER TABLE outbox."outboxMessage" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 93763)
-- Name: KitchenTask; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."KitchenTask" (
    "Id" uuid NOT NULL,
    "Description" text NOT NULL,
    "Status" text NOT NULL,
    "Kitchener" text NOT NULL,
    "PreparationDate" timestamp with time zone NOT NULL
);


ALTER TABLE public."KitchenTask" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 93771)
-- Name: Label; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Label" (
    "Id" uuid NOT NULL,
    "ProductionDate" timestamp with time zone NOT NULL,
    "ExpirationDate" timestamp with time zone NOT NULL,
    "DeliberyDate" timestamp with time zone NOT NULL,
    "Detail" text NOT NULL,
    "Address" text NOT NULL,
    "ContractId" uuid NOT NULL,
    "PatientId" uuid NOT NULL,
    "DeliberyId" uuid NOT NULL,
    "Status" boolean NOT NULL
);


ALTER TABLE public."Label" OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 93787)
-- Name: Package; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Package" (
    "Id" uuid NOT NULL,
    "Status" text NOT NULL,
    "LabelId" uuid NOT NULL
);


ALTER TABLE public."Package" OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 93795)
-- Name: PreparedFood; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PreparedFood" (
    "Id" uuid NOT NULL,
    "IdKitchenTask" uuid NOT NULL
);


ALTER TABLE public."PreparedFood" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 93800)
-- Name: Recipe; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Recipe" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL
);


ALTER TABLE public."Recipe" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 93808)
-- Name: RecipePreparation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RecipePreparation" (
    "Id" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "Detail" text NOT NULL,
    "MealTime" text NOT NULL,
    "PreparationDate" timestamp with time zone NOT NULL,
    "PatientId" uuid NOT NULL
);


ALTER TABLE public."RecipePreparation" OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 93757)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 2843 (class 0 OID 93779)
-- Dependencies: 200
-- Data for Name: outboxMessage; Type: TABLE DATA; Schema: outbox; Owner: postgres
--



--
-- TOC entry 2841 (class 0 OID 93763)
-- Dependencies: 198
-- Data for Name: KitchenTask; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2842 (class 0 OID 93771)
-- Dependencies: 199
-- Data for Name: Label; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2844 (class 0 OID 93787)
-- Dependencies: 201
-- Data for Name: Package; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2845 (class 0 OID 93795)
-- Dependencies: 202
-- Data for Name: PreparedFood; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2846 (class 0 OID 93800)
-- Dependencies: 203
-- Data for Name: Recipe; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Recipe" VALUES ('f837239f-1323-475c-be7b-e4d7f926e52a', 'Espaguetis a la Carbonara', 'Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.');
INSERT INTO public."Recipe" VALUES ('65ce4e7a-fad7-406f-b454-dbb79a040641', 'Pollo Tikka Masala', 'Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.');
INSERT INTO public."Recipe" VALUES ('f6ed0fe2-a6c1-4918-b1b6-53c59c2b6219', 'Lasaña de Carne', 'Una deliciosa lasaña al horno con capas de pasta, carne molida, salsa de tomate y bechamel, gratinada con queso.');


--
-- TOC entry 2847 (class 0 OID 93808)
-- Dependencies: 204
-- Data for Name: RecipePreparation; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2840 (class 0 OID 93757)
-- Dependencies: 197
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20250703095149_InitialCreate', '9.0.5');


--
-- TOC entry 2710 (class 2606 OID 93786)
-- Name: outboxMessage PK_outboxMessage; Type: CONSTRAINT; Schema: outbox; Owner: postgres
--

ALTER TABLE ONLY outbox."outboxMessage"
    ADD CONSTRAINT "PK_outboxMessage" PRIMARY KEY ("outboxId");


--
-- TOC entry 2706 (class 2606 OID 93770)
-- Name: KitchenTask PK_KitchenTask; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."KitchenTask"
    ADD CONSTRAINT "PK_KitchenTask" PRIMARY KEY ("Id");


--
-- TOC entry 2708 (class 2606 OID 93778)
-- Name: Label PK_Label; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Label"
    ADD CONSTRAINT "PK_Label" PRIMARY KEY ("Id");


--
-- TOC entry 2712 (class 2606 OID 93794)
-- Name: Package PK_Package; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Package"
    ADD CONSTRAINT "PK_Package" PRIMARY KEY ("Id");


--
-- TOC entry 2714 (class 2606 OID 93799)
-- Name: PreparedFood PK_PreparedFood; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PreparedFood"
    ADD CONSTRAINT "PK_PreparedFood" PRIMARY KEY ("Id");


--
-- TOC entry 2716 (class 2606 OID 93807)
-- Name: Recipe PK_Recipe; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Recipe"
    ADD CONSTRAINT "PK_Recipe" PRIMARY KEY ("Id");


--
-- TOC entry 2718 (class 2606 OID 93815)
-- Name: RecipePreparation PK_RecipePreparation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RecipePreparation"
    ADD CONSTRAINT "PK_RecipePreparation" PRIMARY KEY ("Id");


--
-- TOC entry 2704 (class 2606 OID 93761)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 2854 (class 0 OID 0)
-- Dependencies: 7
-- Name: SCHEMA public; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2025-07-04 00:46:45

--
-- PostgreSQL database dump complete
--

