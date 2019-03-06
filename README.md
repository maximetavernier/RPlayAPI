# RPlayAPI

## Utils

### Create rplay-db image

`docker-compose build && docker tag rplay-pgsql maximetavernier92/rplay-pgsql`

### Clean images locally

`docker rm -f $(docker ps -a -q) && docker rmi -f $(docker images -q)`