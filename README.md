The slim build of Zipkin is smaller and starts faster. It supports in-memory and Elasticsearch storage, but doesn't support messaging transports like Kafka or RabbitMQ. If these constraints match your needs, you can try slim like below:

Running via Java:

curl -sSL https://zipkin.io/quickstart.sh | bash -s io.zipkin:zipkin-server:LATEST:slim zipkin.jar
java -jar zipkin.jar
