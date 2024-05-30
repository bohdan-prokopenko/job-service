## Build and Run Locally
1. Open the project in Visual Studio.
2. Build the solution.
3. Run the application.
4. Send a POST request:
5. Use a tool like Postman.
6. URL: http://localhost:5000/api/job
7. Body: Provide job details in JSON format.
------------
## Build Docker Image
1. Navigate to the project directory.
2. Build the Docker image:
3. bash
4. Copy code
5. docker build -t job-cost-calculator .
6. Run the Docker container:
```bash
docker run -d -p 8080:80 job-cost-calculator
```
------------
## Deploy to Kubernetes with Helm
1. Package the Helm chart:
```bash
helm package ./deployment-configuration
```
2. Deploy the chart:
```bash
helm install job-service ./job-service-0.1.0.tgz
```
