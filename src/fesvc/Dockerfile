FROM nginx:latest

COPY ./default.conf /etc/nginx/conf.d/

WORKDIR /app

COPY . /app

RUN chmod 755 /app/init_container.sh

EXPOSE 8888 8889

ENTRYPOINT "/app/init_container.sh"

