CREATE EXTENSION pgcrypto;

--  Reference table
CREATE TABLE lang (
	id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
	iso char(2) NOT NULL,
	name text NOT NULL
);
CREATE UNIQUE INDEX ix__lang__id on lang(id);

--  Reference table
CREATE TABLE country (
	id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
	iso char(2) NOT NULL,
	code smallint unique not null,
    name char(64) not null
);
CREATE UNIQUE INDEX ix__country__id on country(id);

-- Reference table
CREATE TABLE locale (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    lang_id uuid NOT NULL REFERENCES lang(id),
    country_id uuid NOT NULL REFERENCES country(id),
    iso char(5) NULL
);
CREATE UNIQUE INDEX ix__locale__id on locale(id);

-- Reference table
CREATE TABLE user_role (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    title char(32) NOT NULL,
    description text NULL,
    is_radio boolean NOT NULL default false,
    is_salon boolean NOT NULL default false
);
CREATE UNIQUE INDEX ix__user_role__id on user_role(id);

-- Reference table
CREATE TABLE user_status (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    title char(32) NOT NULL,
    description text NULL,
    is_radio boolean NOT NULL default false,
    is_salon boolean NOT NULL default false
);
CREATE UNIQUE INDEX ix__user_status__id on user_status(id);


CREATE TABLE abstract_user (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    creation_date timestamp NOT NULL DEFAULT LOCALTIMESTAMP
);
CREATE UNIQUE INDEX ix__abstract_user__id on abstract_user(id);

CREATE TABLE metadata (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    creation_user_id uuid NOT NULL REFERENCES abstract_user(id),
    creation_date timestamp NOT NULL DEFAULT LOCALTIMESTAMP,
    update_user_id uuid NULL REFERENCES abstract_user(id),
    update_date timestamp NULL
);
CREATE UNIQUE INDEX ix__metadata__id on metadata(id);

CREATE TABLE user_login (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    user_id uuid NOT NULL REFERENCES abstract_user(id),
    login char(256) NOT NULL
);
CREATE UNIQUE INDEX ix__user_login__user_id on user_login(user_id);
CREATE UNIQUE INDEX ix__user_login__login on user_login(login);

CREATE TABLE shadow_passwd (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    user_id uuid NOT NULL REFERENCES abstract_user(id),
    hash char(40) NOT NULL
);
CREATE UNIQUE INDEX ix__shadow_passwd__user_id on shadow_passwd(user_id);

CREATE TABLE platform_user (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    abstract_id uuid NOT NULL REFERENCES abstract_user(id),
    locale_id uuid NULL REFERENCES locale(id),
    firstname char(128) NOT NULL,
    lastname char(128) NOT NULL,
    email char(128) NOT NULL,
    image_url char(512) NULL,
    gender bit NOT NULL default 0::bit,
    birthday date NULL
);
CREATE UNIQUE INDEX ix__user__id on platform_user(id);
CREATE UNIQUE INDEX ix__user__abstract_id on platform_user(abstract_id);
CREATE UNIQUE INDEX ix__user__email on platform_user(email);

CREATE TABLE preferences (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    user_id uuid NOT NULL REFERENCES abstract_user(id),
    is_visible boolean NOT NULL default true
);
CREATE UNIQUE INDEX ix__preferences__user_id on preferences(user_id);

CREATE TABLE radio_instance (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    hash char(8) UNIQUE NOT NULL,
    name char(128) NULL
);
CREATE UNIQUE INDEX ix__radio_instance__id on radio_instance(id);
CREATE UNIQUE INDEX ix__radio_instance__hash on radio_instance(hash);

CREATE TABLE radio_user (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_id uuid NOT NULL REFERENCES radio_instance(id),
    user_id uuid NOT NULL REFERENCES abstract_user(id)
);
CREATE UNIQUE INDEX ix__radio_user__id on radio_user(id);

CREATE TABLE radio_user_role (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_user_id uuid NOT NULL REFERENCES radio_user(id),
    role_id uuid NOT NULL REFERENCES user_role(id)
);
CREATE UNIQUE INDEX ix__radio_user_role__id on radio_user_role(id);

CREATE TABLE radio_user_status (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_user_id uuid NOT NULL REFERENCES radio_user(id),
    status_id uuid NOT NULL REFERENCES user_status(id)
);
CREATE UNIQUE INDEX ix__radio_user_status__id on radio_user_status(id);

CREATE TABLE radio_settings (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_id uuid NOT NULL REFERENCES radio_instance(id),
    is_public boolean NOT NULL default true
);
CREATE UNIQUE INDEX ix__radio_settings__id on radio_settings(id);
CREATE UNIQUE INDEX ix__radio_settings__radio_id on radio_settings(radio_id);

CREATE TABLE song (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    title char(256) NOT NULL,
    artiste char(256) NOT NULL,
    url char(512) NOT NULL
);
CREATE UNIQUE INDEX ix__song__id on song(id);

CREATE TABLE playlist_info (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id)
);
CREATE UNIQUE INDEX ix__playlist_info__id on playlist_info(id);

CREATE TABLE playlist (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    info_id uuid NOT NULL REFERENCES playlist_info(id),
    song_id uuid NOT NULL REFERENCES song(id)
);
CREATE UNIQUE INDEX ix__playlist__id on playlist(id);

-- salon: radio + playlist
CREATE TABLE salon (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_id uuid NOT NULL REFERENCES radio_instance(id),
    playlist_id uuid NULL REFERENCES playlist_info(id),
    owner_id uuid NOT NULL REFERENCES abstract_user(id),
    hash char(8) UNIQUE NOT NULL,
    name char(128) NULL,
    description text NULL
);
CREATE UNIQUE INDEX ix__salon__id on salon(id);
CREATE UNIQUE INDEX ix__salon__hash on salon(hash);

CREATE TABLE salon_history (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    salon_id uuid NOT NULL REFERENCES salon(id),
    song_id uuid NOT NULL REFERENCES song(id),
    added_by uuid NULL REFERENCES abstract_user(id),
    added_date timestamp NOT NULL,
    removed_date timestamp NULL
);
CREATE UNIQUE INDEX ix__salon_history__id on salon_history(id);

CREATE TABLE salon_user_role (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_user_id uuid NOT NULL REFERENCES radio_user(id),
    role_id uuid NOT NULL REFERENCES user_role(id)
);
CREATE UNIQUE INDEX ix__salon_user_role__id on salon_user_role(id);
CREATE UNIQUE INDEX ix__salon_user_role__user_id on salon_user_role(radio_user_id);

CREATE TABLE salon_user_status (
    id uuid UNIQUE NOT NULL DEFAULT gen_random_uuid() PRIMARY KEY,
    metadata_id uuid NOT NULL REFERENCES metadata(id),
    radio_user_id uuid NOT NULL REFERENCES radio_user(id),
    status_id uuid NOT NULL REFERENCES user_status(id)
);
CREATE UNIQUE INDEX ix__salon_user_status__id on salon_user_status(id);
CREATE UNIQUE INDEX ix__salon_user_status__user_id on salon_user_status(radio_user_id);
