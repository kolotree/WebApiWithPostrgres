CREATE TABLE IF NOT EXISTS "User"(
    "UserId" SERIAL,
	"UserName" character varying(256),
	"PasswordHash" character varying(256),
    PRIMARY KEY ("UserId"),
	UNIQUE ("UserName")
);


CREATE OR REPLACE FUNCTION CreateUser(
	UserName TEXT,
	PasswordHash TEXT
)
RETURNS void AS $$
BEGIN
    INSERT INTO "User" ("UserName", "PasswordHash") VALUES (UserName, PasswordHash);
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION SearchUser (
	UserName TEXT
)
RETURNS SETOF "User" AS $$
DECLARE rec record;
BEGIN
	FOR rec IN (
        SELECT * FROM "User"
            WHERE ("UserName" = UserName)
        ) LOOP
        RETURN NEXT rec;
    END LOOP;
END;
$$ LANGUAGE 'plpgsql';