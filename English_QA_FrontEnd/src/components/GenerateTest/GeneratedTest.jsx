import axios from "axios";
import React,{useState,useEffect} from "react";
import { json, useLocation } from "react-router-dom";
import { useNavigate } from 'react-router-dom';

function GeneratedTest(){
    const location = useLocation();
    const [questions,setQuestions] = useState([]);
    const [answers, setAnswers] = useState([]);
    const [activeAnswer,setActiveAnswer] = useState([]);
    const jwtToken = localStorage.getItem("token");
    const navigate = useNavigate();
  const { data } = location.state || {};  // Retrieve data from navigation state
  const symbols = "====>";

  // Save questions in localStorage to prevent losing them when the user changes the URL
useEffect(() => {
  const hasQuestions = data?.value;
  
  if (hasQuestions) {
      localStorage.setItem("questions", JSON.stringify(hasQuestions));
  }
}, [data]);

  // Save answers in localStorage to prevent losing them when the user changes the URL
    useEffect(() => {
   const hasAnswers = answers && Object.keys(answers).length > 0;
    
    if (hasAnswers) {
      localStorage.setItem("answers", JSON.stringify(answers));
        }
      }, [answers]);

// Retrieve questions and answers from localStorage and store them in useState

   useEffect(() => {
  const storedQuestions = localStorage.getItem("questions");
  const storedAnswers = localStorage.getItem("answers");
  if (storedQuestions) {
    setQuestions(JSON.parse(storedQuestions));
  }

  if (storedAnswers) {
    setAnswers(JSON.parse(storedAnswers));
  }
}, []);
  
  
  const handleAnswer = (index, value,answerType) => {
    

    if(answerType === 1){
      setAnswers(prev => ({ ...prev, [index]: value }));
    }
    else{
       activeAnswer[index] === value ? setActiveAnswer(prev => ({ ...prev, [index]: null }))
       : setActiveAnswer(prev => ({ ...prev, [index]: value })); 
       answers[index] === value ? setAnswers(prev => ({ ...prev, [index]: null })) 
       : setAnswers(prev => ({ ...prev, [index]: value }));
    }
    
    
  };

  async function handleSubmitTest (){
    const resultsToSubmit = questions
    .map((q, index) => {
      const userAnswer = answers[index];
      if (!userAnswer) return null; // skip unanswered questions

      return {
        userTestID: q.id,
        userAnswer: userAnswer,
        userMultipleAnswer: "",
        correctAnswer: 0,
        countQuestions: questions.length
      };
    })
    .filter(Boolean);
       
    try {
    const response = await axios.post("http://localhost:8095/TestResults/AddResult", resultsToSubmit, {
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      }
      
    });

       localStorage.removeItem("answers");

       if(response.data){
      console.log("All answers submitted", response.data);
      navigate("/TestResults", { state: { data: response.data } });
       }
      
  } catch (error) {
    if (error.response?.status === 400) {
      setError("Only letters are allowed in the answers");// i have to create it
    } else {
      console.error("Submission failed:", error);
      setError("Something went wrong. Please try again.");
      }
    }
  }

  return (
    <div className="GeneratedTestStyle">
      <h2>Generated Test Data</h2>
      {questions ? (
       questions.map((item, index) => (
           (item.answerTypeID === 1 ?
          <div key={index} >
            
            <p>{item.question}</p>
            <p id="symbol">{symbols}</p>
            <input type="text" placeholder="Your answer" value={answers[index] || ""}
            onChange={(e) => handleAnswer(index,e.target.value,item.answerTypeID)} />
            
          </div>
          : <div key={index} >
            
            <p>{item.question}</p>
             

            <div className="multipleChoiceButtons">
              
            <button className={activeAnswer[index] === item.multipleAnswer01 
            ? "multipleChoiceButtonsAnimation" : ""} value={item.multipleAnswer01} 
            onClick={(e)=> handleAnswer(index,e.target.value,item.answerTypeID)}>{item.multipleAnswer01}</button>

            <button className={activeAnswer[index] === item.multipleAnswer02 
            ? "multipleChoiceButtonsAnimation" : ""} value={item.multipleAnswer02} 
            onClick={(e)=> handleAnswer(index,e.target.value,item.answerTypeID)}>{item.multipleAnswer02}</button>

            <button className={activeAnswer[index] === item.multipleAnswer03 
            ? "multipleChoiceButtonsAnimation" : ""} value={item.multipleAnswer03} 
            onClick={(e)=> handleAnswer(index,e.target.value,item.answerTypeID)}>{item.multipleAnswer03}</button>

            <button className={activeAnswer[index] === item.multipleAnswer04 
            ? "multipleChoiceButtonsAnimation" : ""} value={item.multipleAnswer04} 
            onClick={(e)=> handleAnswer(index,e.target.value,item.answerTypeID)}>{item.multipleAnswer04}</button>
                       
            </div>           
          </div>
           )
        ))) : ("")}
      {questions.length > 0 ? <div className="submitAnswer">
      <button onClick={handleSubmitTest}>Submit Your Answers</button></div>
        : <p className="noData">No data to display. Please generate a test first.</p>}
    </div>
  );
    
}
export default GeneratedTest;