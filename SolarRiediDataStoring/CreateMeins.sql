Drop Table IF Exists meins

CREATE TABLE meins
(
	datum int UNIQUE NOT NULL,
	Psum_0 int NOT NULL,
	Psum_1 int NOT NULL,
	Psum_2 int NOT NULL,
	Psum_3 int NOT NULL,
	Psum_4 int NOT NULL,
	Psum_5 int NOT NULL,
	Psum_6 int NOT NULL,
)

CREATE INDEX IX_datum
ON meins (datum)
INCLUDE (
    Psum_0,
	Psum_1,
	Psum_2,
	Psum_3,
	Psum_4,
	Psum_5,
	Psum_6
)