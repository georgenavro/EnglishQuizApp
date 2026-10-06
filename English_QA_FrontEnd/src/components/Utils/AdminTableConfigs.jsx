const tableConfigs = {
  AnswerType: [
    { header: "ID", accessor: "id" },
    { header: "Answer Type", accessor: "answerType" },
  ],
  QuestionCategory: [
    { header: "ID", accessor: "id" },
    { header: "Question Category", accessor: "questionCategory" },
  ],
  users: [
    { header: "ID", accessor: "id" },
    { header: "Name", accessor: "name" },
    { header: "Username", accessor: "username" },
    { header: "UserTypeID", accessor: "userTypeID" },
  ],
  UserType: [
    { header: "ID", accessor: "id" },
    { header: "User Type", accessor: "userType" },
  ],
  QA: [
    { header: "ID", accessor: "id" },
    { header: "Question", accessor: "question" },
    { header: "Answer", accessor: "answer" },
    { header: "MultipleAnswer01", accessor: "multipleAnswer01" },
    { header: "MultipleAnswer02", accessor: "multipleAnswer02" },
    { header: "MultipleAnswer03", accessor: "multipleAnswer03" },
    { header: "MultipleAnswer04", accessor: "multipleAnswer04" },
    { header: "QuestionCategory", accessor: "questionCategory" },
    { header: "AnswerType", accessor: "answerType" },
  ],
  UserTest: [
    { header: "ID", accessor: "id" },
    { header: "Question", accessor: "question" },
    { header: "Answer", accessor: "answer" },
    { header: "MultipleAnswer01", accessor: "multipleAnswer01" },
    { header: "MultipleAnswer02", accessor: "multipleAnswer02" },
    { header: "MultipleAnswer03", accessor: "multipleAnswer03" },
    { header: "MultipleAnswer04", accessor: "multipleAnswer04" },
    { header: "QuestionCategory", accessor: "questionCategory" },
    { header: "AnswerType", accessor: "answerType" },
    { header: "UserID", accessor: "userID" },
    { header: "UserName", accessor: "userName" },
    { header: "TestCount", accessor: "testCount" },
  ],
  TestResults: [
    { header: "ID", accessor: "id" },
    { header: "Question", accessor: "question" },
    { header: "Answer", accessor: "answer" },
    { header: "UserAnswer", accessor: "userAnswer" },
    { header: "CorrectAnswers", accessor: "correctAnswers" },
    { header: "CountQuestions", accessor: "countQuestions" },
    { header: "Results", accessor: "results" },
    { header: "TestPerAttempt", accessor: "testPerAttempt" },
  ],
};

export default tableConfigs;