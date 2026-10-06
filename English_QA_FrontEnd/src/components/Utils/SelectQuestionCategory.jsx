import React, {useState,useEffect} from "react";
import { answerTypes, grammarCategories } from "../Utils/QuestionSelector";

const QuestionCategory = ({setFormData,formData,setCurrentPage,setPageNumber,isUpdateMode}) => {
  const [selectedGrammarArea, setSelectedGrammarArea]= useState([]);
  
    const [updateState,setState] = useState({
        TextButton:false,
        MultiButton:false
      });
  useEffect(() => {
    if(formData.AnswerTypeID === 0){
      setState({
        TextButton:false,
        MultiButton:false
      });
    }
  }, [formData.AnswerTypeID]);

function handleClick(e){
    const value = e.target.value;
          if(formData.AnswerTypeID != value && !isUpdateMode){
            setCurrentPage(1);
            setPageNumber(1);
          }
          setFormData((prevData) => ({
            ...prevData,
            AnswerTypeID: value
          }));
        
      setState(prev => {
    const newState = {};

    // Reset all buttons to false
    for (const key in prev) {
      newState[key] = false;
    }

    newState[value] = !prev[value];

    return newState;
  });
}

function handleSelectedChange(event){
    const value = event.target.value;
    setSelectedGrammarArea(value);
    if(formData.questionCategoryID != value && !isUpdateMode){
            setCurrentPage(1);
            setPageNumber(1);
          }
          setFormData((prevData) => ({
            ...prevData,
            questionCategoryID: value,
          }));
          console.log(value);
        
}
return(
<div>   
<div className="buttonContainer">
  {answerTypes.map((type) => (
    <button
      key={type.value}
      type="Button"
      value={type.value}
      onClick={e=> handleClick(e)}
      className={`GenerateTestButtons ${
        updateState[type.value] ? "Animation" : ""
      }`}
    >
      {type.label}
    </button>
  ))}
</div>
<div>
<select
  className={selectedGrammarArea ? "questionCategory OnlyAnimationSelected" : "questionCategory"}
  onClick={handleSelectedChange}>
    
  {grammarCategories.map((cat) => (
    <option
      key={cat.value}
      value={cat.value}
      className={selectedGrammarArea === String(cat.value) ? "animationSelectedOption" : ""}
    >
      {cat.label}
    </option>
  ))}
</select>
</div>
</div>
)
}
export default QuestionCategory;