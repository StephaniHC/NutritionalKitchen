--
-- PostgreSQL database dump
--

-- Dumped from database version 10.11
-- Dumped by pg_dump version 10.11

-- Started on 2025-07-05 07:33:41

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
-- Name: outbox; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA outbox;


SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 200 (class 1259 OID 94052)
-- Name: outboxMessage; Type: TABLE; Schema: outbox; Owner: -
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


--
-- TOC entry 198 (class 1259 OID 94036)
-- Name: KitchenTask; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."KitchenTask" (
    "Id" uuid NOT NULL,
    "Kitchener" text NOT NULL,
    "PreparationDate" timestamp with time zone NOT NULL
);


--
-- TOC entry 199 (class 1259 OID 94044)
-- Name: Label; Type: TABLE; Schema: public; Owner: -
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


--
-- TOC entry 201 (class 1259 OID 94060)
-- Name: Package; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Package" (
    "Id" uuid NOT NULL,
    "Status" text NOT NULL,
    "LabelId" uuid NOT NULL
);


--
-- TOC entry 202 (class 1259 OID 94068)
-- Name: PreparedFood; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."PreparedFood" (
    "Id" uuid NOT NULL,
    "IdKitchenTask" uuid NOT NULL,
    "IdRecipePreparation" uuid NOT NULL,
    "RecipePreparationDate" timestamp with time zone NOT NULL,
    "Status" text NOT NULL,
    "Recipe" text NOT NULL,
    "Detail" text NOT NULL,
    "PatientId" uuid NOT NULL,
    "LabelId" uuid
);


--
-- TOC entry 203 (class 1259 OID 94076)
-- Name: Recipe; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."Recipe" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Description" text NOT NULL
);


--
-- TOC entry 204 (class 1259 OID 94084)
-- Name: RecipePreparation; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."RecipePreparation" (
    "Id" uuid NOT NULL,
    "RecipeId" uuid NOT NULL,
    "Detail" text NOT NULL,
    "MealTime" text NOT NULL,
    "PreparationDate" timestamp with time zone NOT NULL,
    "PatientId" uuid NOT NULL
);


--
-- TOC entry 197 (class 1259 OID 93757)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


--
-- TOC entry 2844 (class 0 OID 94052)
-- Dependencies: 200
-- Data for Name: outboxMessage; Type: TABLE DATA; Schema: outbox; Owner: -
--



--
-- TOC entry 2842 (class 0 OID 94036)
-- Dependencies: 198
-- Data for Name: KitchenTask; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 2843 (class 0 OID 94044)
-- Dependencies: 199
-- Data for Name: Label; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 2845 (class 0 OID 94060)
-- Dependencies: 201
-- Data for Name: Package; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 2846 (class 0 OID 94068)
-- Dependencies: 202
-- Data for Name: PreparedFood; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 2847 (class 0 OID 94076)
-- Dependencies: 203
-- Data for Name: Recipe; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."Recipe" VALUES ('f837239f-1323-475c-be7b-e4d7f926e52a', 'Espaguetis a la Carbonara', 'Un plato clásico italiano hecho con huevos, queso, panceta y pimienta.');
INSERT INTO public."Recipe" VALUES ('65ce4e7a-fad7-406f-b454-dbb79a040641', 'Pollo Tikka Masala', 'Un sabroso curry con trozos de pollo tierno en una cremosa salsa de tomate.');
INSERT INTO public."Recipe" VALUES ('f6ed0fe2-a6c1-4918-b1b6-53c59c2b6219', 'Lasaña de Carne', 'Una deliciosa lasaña al horno con capas de pasta, carne molida, salsa de tomate y bechamel, gratinada con queso.');


--
-- TOC entry 2848 (class 0 OID 94084)
-- Dependencies: 204
-- Data for Name: RecipePreparation; Type: TABLE DATA; Schema: public; Owner: -
--



--
-- TOC entry 2841 (class 0 OID 93757)
-- Dependencies: 197
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: -
--

INSERT INTO public."__EFMigrationsHistory" VALUES ('20250703095149_InitialCreate', '9.0.5');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250705044451_InitialCreate', '9.0.5');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250705045619_InitialCreate', '9.0.5');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250705092646_InitialCreate', '9.0.5');
INSERT INTO public."__EFMigrationsHistory" VALUES ('20250705112519_InitialCreate', '9.0.5');


--
-- TOC entry 2711 (class 2606 OID 94059)
-- Name: outboxMessage PK_outboxMessage; Type: CONSTRAINT; Schema: outbox; Owner: -
--

ALTER TABLE ONLY outbox."outboxMessage"
    ADD CONSTRAINT "PK_outboxMessage" PRIMARY KEY ("outboxId");


--
-- TOC entry 2707 (class 2606 OID 94043)
-- Name: KitchenTask PK_KitchenTask; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."KitchenTask"
    ADD CONSTRAINT "PK_KitchenTask" PRIMARY KEY ("Id");


--
-- TOC entry 2709 (class 2606 OID 94051)
-- Name: Label PK_Label; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Label"
    ADD CONSTRAINT "PK_Label" PRIMARY KEY ("Id");


--
-- TOC entry 2713 (class 2606 OID 94067)
-- Name: Package PK_Package; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Package"
    ADD CONSTRAINT "PK_Package" PRIMARY KEY ("Id");


--
-- TOC entry 2715 (class 2606 OID 94075)
-- Name: PreparedFood PK_PreparedFood; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."PreparedFood"
    ADD CONSTRAINT "PK_PreparedFood" PRIMARY KEY ("Id");


--
-- TOC entry 2717 (class 2606 OID 94083)
-- Name: Recipe PK_Recipe; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."Recipe"
    ADD CONSTRAINT "PK_Recipe" PRIMARY KEY ("Id");


--
-- TOC entry 2719 (class 2606 OID 94091)
-- Name: RecipePreparation PK_RecipePreparation; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."RecipePreparation"
    ADD CONSTRAINT "PK_RecipePreparation" PRIMARY KEY ("Id");


--
-- TOC entry 2705 (class 2606 OID 93761)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


-- Completed on 2025-07-05 07:33:41

--
-- PostgreSQL database dump complete
--

