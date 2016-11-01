Drop Table IF Exists meins

CREATE TABLE meins
(
	datum int UNIQUE NOT NULL,
	Psum_0 int NOT NULL,
	Pmax_0 int NOT NULL,
	Psum_1 int NOT NULL,
	Pmax_1 int NOT NULL,
	Psum_2 int NOT NULL,
	Pmax_2 int NOT NULL,
	Psum_3 int NOT NULL,
	Pmax_3 int NOT NULL,
	Psum_4 int NOT NULL,
	Pmax_4 int NOT NULL,
	Psum_5 int NOT NULL,
	Pmax_5 int NOT NULL,
	Psum_6 int NOT NULL,
	Pmax_6 int NOT NULL
)

CREATE INDEX IX_datum
ON meins (datum)
INCLUDE (
    Psum_0,
	Pmax_0,
	Psum_1,
	Pmax_1,
	Psum_2,
	Pmax_2,
	Psum_3,
	Pmax_3,
	Psum_4,
	Pmax_4,
	Psum_5,
	Pmax_5,
	Psum_6,
	Pmax_6
)