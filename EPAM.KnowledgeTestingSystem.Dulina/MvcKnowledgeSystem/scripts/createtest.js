
$(document).ready(function () {
    $(document).on('click', '.panel-heading', function () {
        $(this).next(".panel-body").slideToggle("fast");
        return false;
    });

    $(document).on('click', '.create-answer', function () {
        var answer = $("#answer-template").clone();
        answer.find("textarea").val("");
        answer.find("input[type=checkbox]").prop('checked', false);
        var lastAnswerElement = $(this).parent().prev(".form-group");
        answer.insertAfter(lastAnswerElement);
        return false;
    });

    $("#create-question").on('click', function () {
        var question = $("#question-template").clone();
        question.find(".panel-heading").append('<span class="glyphicon glyphicon-remove pull-right"></span>');
        var lastQuestionElement = $(this).parent().prev(".panel");
        question.insertAfter(lastQuestionElement);

        refreshQuestionTitles();
        return false;
    });

    $(document).on('click', '.glyphicon-remove', function () {
        var elementToDelete = $(this).parent().parent();
        $(elementToDelete).remove();

        refreshQuestionTitles();
        return false;
    });

    $(document).on('click', '#create-test', function () {
        saveTest();
        return false;
    });
});

function refreshQuestionTitles() {
    var indexNumber = 2;
    var currentQuestion = $("#question-template");
    while (true) {
        currentQuestion = currentQuestion.next();
        if (currentQuestion.length !== 0 && $(currentQuestion).hasClass("panel")) {
            $($(currentQuestion).find(".panel-heading span:first")).text('Question ' + indexNumber);
            indexNumber++;
        } else {
            break;
        }
    }
}

function saveTest() {
    $('#loadingmessage').show();

    var test = {'Title': '', 'Topic': '', 'TimeLimit': 0, "Questions": []};
    test.Title = $("input[name='title']").val();
    test.Topic = $("input[name='topic']").val();
    test.TimeLimit = +$("input[name='timeinterval']").val();

    var currentQuestion = $("#question-template");
    while (true) {
        var question = {"Text": '', "Answers": []};

        if (currentQuestion.length !== 0 && $(currentQuestion).hasClass("panel")) {
            var currentQuestionText = $($(currentQuestion).find("input:first")).val();
            var currentAnswer = $(currentQuestion).find("#answer-template");
            question.Text = currentQuestionText;

            while (true) {

                if (currentAnswer.length !== 0 && $(currentAnswer).hasClass("center-form-group")) {
                    var currentAnswerCorrect = currentAnswer.find("input[type=checkbox]").prop('checked');
                    var currentAnswerText = currentAnswer.find("textarea").val();
                    question.Answers.push({"Text": currentAnswerText, "IsCorrect": currentAnswerCorrect});
                } else {
                    break;
                }

                currentAnswer = currentAnswer.next();
            }
        } else {
            break;
        }

        test.Questions.push(question);
        currentQuestion = currentQuestion.next();
    }

    $.ajax({
        url: '/admin/createtest',
        data: JSON.stringify(test),
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            showSuccessMessage();
            $('#loadingmessage').hide();
        },
        error: function (error) {
            showErrorMessage();
        }
    });

}

function showSuccessMessage() {
    document.querySelector(".container-fluid").innerHTML = '<span style="color:green">Test successfully created</span>';
}

function showErrorMessage() {
    document.querySelector(".container-fluid").innerHTML = '<span style="color:red">Something went wrong</span>';
}