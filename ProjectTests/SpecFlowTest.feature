Feature: AddQuestion
    Scenario: User adds a new question
        Given I have a question service
        When I add a new question
        Then The question should be added to the database