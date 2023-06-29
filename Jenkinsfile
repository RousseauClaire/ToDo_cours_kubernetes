pipeline{
    agent any
    stages{
        stage('git checkout'){
            steps{
                git credentialsId: 'RousseauClaire/******',url:'https://github.com/RousseauClaire/ToDo_cours_kubernetes.git'
            }
        }
        stage('Build the application'){
            steps{
                bat 'mvn clean install'
            }
        }
        stage('Unit Test Execution') {
            steps{
                bat 'mvn test'
            }
        }
        stage('Build the docker image') {
            steps{
                bat "docker build -t rousseauclaire/jenkinstp2 ."
            }
        }
        stage('Push the docker image') {
            steps{
                withCredentials([string(credentialsId: 'dockerhubpassword', variable: 'dockerHubPass')]) {
                    bat "docker login -u rousseauclaire -p $dockerHubPass"
                }
                bat "docker push rousseauclaire/jenkinstp2"
            }
        }
    }
}