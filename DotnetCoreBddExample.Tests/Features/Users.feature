Feature: Users Resource
	In order to set up a new user account 
	As a client application
	I want to be able to create and update a user 

Scenario: Create new user
Given I am a client
When I make a post request to '/users' with the following data '{ "firstName" : "Jinu","lastName":"George","emailAddress":"jinu.g@deltax.com","loginPassword":"ads4good" }'
Then the response status code is '200'
And the response data should be '{"id":1}'