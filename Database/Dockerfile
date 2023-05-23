FROM mysql:8.0.31

ENV MYSQL_ROOT_PASSWORD=restaurante
ENV MYSQL_DATABASE=restaurante

COPY ./scripts /docker-entrypoint-initdb.d

EXPOSE 3306