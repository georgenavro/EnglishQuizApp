import React, {useState,useEffect} from "react";
import axios from "axios";
import { useNavigate } from 'react-router-dom';
import "./../../../public/GenerateTest.css";
import { GoArrowDownLeft } from "react-icons/go";
import { GoArrowDownRight } from "react-icons/go";
import { GoArrowDown } from "react-icons/go";
import { CgCloseO } from "react-icons/cg";

function questionsAnswers(){
    const [updateState, setState] = useState({
            MultiButton: false,
            TextButton: false
        }); //this is for buttons to animated
    const navigate = useNavigate();
    const [selectedQuestionType, setSelectedQuestionType] = useState(null); //Choose either "Text" or "Multi"
    const [selectedGrammarArea, setSelectedGrammarArea] = useState(null);//Grammar Popup Window
    const [error, setError] = useState("Ready to start a new test? Choose one of the options below:");
    const [errorMessage, setErrorMessage] = useState("");
    const userID = localStorage.getItem("userID"); // User ID needed for multiple requests
    const jwtToken = localStorage.getItem("token");// Token required for every request
    const [data,setData] = useState([]);// Store data here

    //Genetate New Test
    async function handleGenerateTest(){
        
        if(selectedGrammarArea === null){
            setError("You have to choose one item from the pop up items");
            return ;
        }
        else if(selectedQuestionType === null){
            setError("You have to choose one of the two buttons");
            return ;
        }
        
        const generateTestParameterRequest = {
            AnswerTypeID: selectedQuestionType === "TextButton" ? 1 : 2,
            questionCategoryID: selectedGrammarArea,
            userID: userID,
            quantity: 10
           };
            
        const response = await axios.post("http://localhost:8095/UserTest/GenerateTest", generateTestParameterRequest, {
              headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${jwtToken}`  
              }});
              if(response.status === 400){
                setError("There are not many questions in this field. Choose less questions or different area");}
            console.log("Data submitted:", response.data);
            localStorage.removeItem('answers');
            navigate("/GeneratedTest",{ state: { data: response.data } });
        }

    //get previous test as buttons 
    async function handleGetPreviousGeneratedTest(){
          
            const response = await axios.post("http://localhost:8095/UserTest/GetPreviousUserTests", userID, {
              headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${jwtToken}`  
              }
            });
              if(response.status === 400){
                setError("");}
            console.log("Data submitted:", response.data);
           const dataWithNames = response.data.map(item => {
            // Get the AnswerType name based on its numeric ID
      const answerTypeName = item.answerTypeID === 1 ? "Text" : "Multiple Choice";
        //Store AreaOfQuestion names
      const questionCategoryNameMap = {
        1: "No Category",
        2: "Simple Present",
        3: "Simple Past",
        4: "Present Perfect",
        5: "Simple Future",
        6: "Present-Past",
        7: "Present-Future",
        8: "Past-Future",
        9: "Present-Past Perfect",
        10: "Present-Future Perfect",
        11: "Past-Future Perfect"
      };
      //Get the name based on the user's selected option
      const questionCategoryName = questionCategoryNameMap[item.questionCategoryID] || "Unknown";

      return {
        ...item,
        answerTypeName,
        questionCategoryName
      };
    });
    //Store all response data in the Data variable
    setData(dataWithNames);
    }

     // Check if any previous questions exist     
    useEffect(() => {
    handleGetPreviousGeneratedTest();
    
    }, []);

    // Get the user's selected test from their previous attempts
    async function GetUserTestSelection(testID){
    
       const getUserTestSelection = {
            Id: data[testID].id,
            userID: userID,
            questionCategoryID: data[testID].questionCategoryID,
            answerTypeID: data[testID].answerTypeID,
            quantity: 10
            };
            const response = await axios.post("http://localhost:8095/UserTest/GetUserTestSelection", getUserTestSelection, {
              headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${jwtToken}`  // Ensure JSON content type is set
              }});
              if(response.status === 400){
                setError("");}
            console.log("Data submitted:", response.data);
            localStorage.removeItem('answers');
             navigate("/GeneratedTest",{ state: { data:{value: response.data } }});
    }

    //Animation buttons
    function handleClick(e){
      const value = e.target.value;

        setState(prev => {
    const newState = {};

    // Reset all buttons to false
    for (const key in prev) {
      newState[key] = false;
    }

    // Toggle clicked one
    newState[value] = !prev[value];

    if(newState["TextButton"] === true && newState["MultiButton"] === false){
      setSelectedQuestionType(value);
    }
    else if(newState["TextButton"] === false && newState["MultiButton"] === true){
      setSelectedQuestionType(value);
    }
    else{
      setSelectedQuestionType(null);
    }
    return newState;
  });
    }
    
    function handleSelectedChange(event){
        setSelectedGrammarArea(event.target.value);
    }


    async function removeGeneratedTest(id){
      try{
      const response = await axios.delete("http://localhost:8095/UserTest/Delete", {
            headers: {
              "Content-Type": "application/json",
              "Authorization": `Bearer ${jwtToken}`
            },
            data: id
            });
                console.log("Data removed");
                window.location.reload();
          }
          catch{
                setErrorMessage("Before deleting this test, please make sure to remove all of its results.");              
          }
    }

    return <div className="genTestStyle">
        <div className="previousTest">
            <p id="errorMessage">{errorMessage}</p>
            <p>Previous Tests</p>
           {data ? (
             
            data.map((item, index) => (
            
          <div className="previousTest" key={index} >
            
            <p>Test #{item.testCount}:
                <button
                value={`GenerateTestButtons_${index}`}
                className="previousTestButton"
                onClick={() => GetUserTestSelection(index)}>
                  {item.answerTypeName}, {item.questionCategoryName}
                </button>

                <button value={`GenerateTestButtons_${index}`}
                className="removePreviousTestButton"
                onClick={() => removeGeneratedTest(item.id)}><span className="removeIcon"><CgCloseO/></span></button>
            </p>
            
            </div>
              ))
            ) : (<p>No Data</p>)}
        </div>
        <h1>{error}</h1>
        <div className="iconsArrows">
        <span className="arrow-left"><GoArrowDownLeft/></span>
        <span className="arrow-right"><GoArrowDownRight/></span>
        <span className="arrow-down"><GoArrowDown/></span>
        </div>
        <div className="buttonContainer">
        <button value="TextButton" onClick={e=> handleClick(e)}
        className={`GenerateTestButtons ${updateState.TextButton ? "Animation" : ""}`}>
          Text</button>
        
        <button value="MultiButton" onClick={handleClick}
        className={`GenerateTestButtons ${updateState.MultiButton ? "Animation": ""}`}
        >Multiple Choice</button>
        </div>
        <div className="iconsArrows">
        <span><GoArrowDownRight/></span>
        <span><GoArrowDownLeft/></span>
        </div>
        <select className={selectedGrammarArea ? "questionCategory OnlyAnimationSelected" : "questionCategory"}
         onClick={handleSelectedChange}>
            
            <option  value={1}
            className={selectedGrammarArea === "1" ? "animationSelectedOption" : ""}>No Category</option>
            
            <option value={2} 
            className={selectedGrammarArea === "2" ? "animationSelectedOption" : ""}>Simple Present</option>
            
            <option value={3} 
            className={selectedGrammarArea === "3" ? "animationSelectedOption" : ""}>Simple Past</option>
            
            <option value={4} 
            className={selectedGrammarArea === "4" ? "animationSelectedOption" : ""}>Present Perfect</option>
            
            <option value={5} 
            className={selectedGrammarArea === "5" ? "animationSelectedOption" : ""}>Simple Future</option>
            
            <option value={6} 
            className={selectedGrammarArea === "6" ? "animationSelectedOption" : ""}>Present-Past</option>
            
            <option value={7} 
            className={selectedGrammarArea === "7" ? "animationSelectedOption" : ""}>Present-Future</option>
            
            <option value={8} 
            className={selectedGrammarArea === "8" ? "animationSelectedOption" : ""}>Past-Future</option>
            
            <option value={9} 
            className={selectedGrammarArea === "9" ? "animationSelectedOption" : ""}>Present-Past Perfect</option>
            
            <option value={10} 
            className={selectedGrammarArea === "10" ? "animationSelectedOption" : ""}>Present-Future Perfect</option>
            
            <option value={11} 
            className={selectedGrammarArea === "11" ? "animationSelectedOption" : ""}>Past-Future Perfect</option>
            
        </select>
        <div className="iconsArrows topArrow">
            <GoArrowDown/>
        </div>
        <div className="submitButton"><button value="GenerateTestButton" onClick={handleGenerateTest}
        >Generate Test</button></div>
    </div>


}

export default questionsAnswers;
