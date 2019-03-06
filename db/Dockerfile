FROM postgres:latest
EXPOSE 5432
COPY configs/rplay-pgsql.conf /etc/postgresql/postgresql.conf
COPY sql/10-init.sql /docker-entrypoint-initdb.d/10-init.sql
COPY sql/20-dump.sql /docker-entrypoint-initdb.d/20-dump.sql
COPY sql/30-setup.sql /docker-entrypoint-initdb.d/30-setup.sql
