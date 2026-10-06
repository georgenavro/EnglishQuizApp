//import "../../../public/AddRemove_Data.css";
import React, {useState , useEffect} from "react";
import axios, { Axios } from "axios";
import { FaUserAlt } from "react-icons/fa";
import { BiSolidLock } from "react-icons/bi";
import { ImUserTie } from "react-icons/im";
import { TbPencilQuestion } from "react-icons/tb";
import { MdQuestionAnswer } from "react-icons/md";
import QuestionCategory from "./selectQuestionCategory";
import RegisterQuestion from "./RegisterQuestion";


function HandleAddRemove({id,selected,isUpdateMode,setSuccessMessage,setErrorMessage, setReloadKey}){

    const jwtToken = localStorage.getItem("token");
    
    let initialData = {};

    if(isUpdateMode && selected === "users"){
        initialData = {
        id: id,
        Name:"",
        Username:"",
        Password: "",
        ConfPassword: "",
        UserTypeID:0
      }
    }
    else if(isUpdateMode && selected === "QA"){
       initialData = {
        id: id,
        Question: "",
        Answer: "",
        MultipleAnswer01: "",
        MultipleAnswer02: "",
        MultipleAnswer03: "",
        MultipleAnswer04: "",
        AnswerTypeID: 0,
        questionCategoryID: 1
      }
    }
    else if(selected === "users"){
      initialData = {
        Name:"",
        Username:"",
        Password: "",
        ConfPassword: "",
        UserTypeID:0
      }
    }
    else if(selected === "QA"){
        initialData = {
        Question: "",
        Answer: "",
        MultipleAnswer01: "",
        MultipleAnswer02: "",
        MultipleAnswer03: "",
        MultipleAnswer04: "",
        AnswerTypeID: 0,
        questionCategoryID: 1
      }
    }
    else if(isUpdateMode){
       initialData = {
        id: id,
        [selected]: ""
      }
    }
    else{
      initialData = {
        id: 0,
        [selected]: ""
      }
    }


    const [formData,setFormData] = useState(initialData);
    const categoryChoices  = ["AnswerType","QuestionCategory","UserType"];
    

     const handleChange = (e) => {
      const { name, value } = e.target;


    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));

     };

     function handleVariable(e){
      let value = e.target.value;
      if(value === "QuestionCategory"){
        value = "questionCategory";

      }
        setFormData(prev => ({
        ...prev,
        [selected]: value
        }));
    }

    async function add_Value(){

         try{

      const response = await axios.post(`http://localhost:8095/${selected}/Add`,formData,{
        headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      }
      });
      setSuccessMessage("The item was added successfully.");
      setReloadKey(prev => prev+1);
      setFormData(initialData);
      
      
    }catch(error){
      console.log(error);
      setErrorMessage("Something went wrong. Please try again.");
      setReloadKey(prev => prev+1);
    }
  }

   async function updateValue() {

   try {
    const response = await axios.put(`http://localhost:8095/${selected}/Update`, formData, {
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      }
    });
    
    setSuccessMessage("The item was updated successfully.");
    setReloadKey(prev => prev+1);

  } catch (error) {
    
    if (error.response?.status === 400) {
       setErrorMessage("Only letters are allowed!");
       setReloadKey(prev => prev+1);
    } else {
      console.error("Submission failed:", error);
       setErrorMessage("Something went wrong. Please try again.");
       setReloadKey(prev => prev+1);
      }
    }
     
  }


return (

  <div>

    {categoryChoices.includes(selected) ? (
    <div className="AddField" >

      <label htmlFor="valueInput">Enter The new Value:</label>
      <input onChange={(e) => handleVariable(e)} id="valueInput" type="Text"/>
      <button onClick={isUpdateMode ? updateValue : add_Value}>Submit</button>

    </div>
    )
    : selected === "users" ?
     <div className="AddField" >

      <form onSubmit={(e) => {
        e.preventDefault();
        isUpdateMode ? updateValue(e) : add_Value(e);
      }}>

         <div className="registerInputs changeColor">
            <span className="icon"><ImUserTie /></span>
         <input name="Name" onChange={(e) =>handleChange(e)} type="text" placeholder="Full Name" />
         </div>

         <div className="registerInputs">
            <span className="icon"><FaUserAlt /></span>
         <input name="Username" onChange={(e) =>handleChange(e)}  type="text" placeholder="Username" />
         </div>

         <div className="registerInputs">
            <span className="icon"><BiSolidLock /></span>
         <input name="Password" onChange={(e) =>handleChange(e)}  type="password" placeholder="Password" />
         </div>

         <div className="registerInputs">
            <span className="icon"><BiSolidLock /></span>
         <input name="ConfPassword" onChange={(e) =>handleChange(e)}  type="password" placeholder="Confirm Password" />
         </div>

          <div className="registerInputs">
            <span className="icon"><FaUserAlt /></span>
         <input name="UserTypeID" onChange={(e) =>handleChange(e)}  type="number" placeholder="User Type" />
         </div>
          <button id="AddValue" type="submit">Submit</button>
         </form>



    </div>
    : selected === "QA" ?
    <div className="AddField">

      <form onSubmit={(e) => {
          e.preventDefault();
          isUpdateMode ? updateValue(e) : add_Value(e);
        }}>

         <div className="registerInputs changeColor">
            <span className="icon"><TbPencilQuestion /></span>
         <input name="Question" value={formData.Question} onChange={(e) =>handleChange(e)} type="text" placeholder="Question" />
         </div>

         <div className="registerInputs">
            <span className="icon"><MdQuestionAnswer /></span>
         <input name="Answer" value={formData.Answer} onChange={(e) =>handleChange(e)}  type="text" placeholder="Answer" />
         </div>

          <QuestionCategory
         setFormData={setFormData} formData={formData} isUpdateMode={true} />

          {formData.AnswerTypeID == 2 ?

       <div>
        {[ formData.MultipleAnswer01,
            formData.MultipleAnswer02,
            formData.MultipleAnswer03,
            formData.MultipleAnswer04
          ].includes(formData.Answer) ? "" :
        <p>One of the four options must match the correct answer.</p>}
        <RegisterQuestion index={1} formData={formData} setFormData={setFormData}/>
        <RegisterQuestion index={2} formData={formData} setFormData={setFormData}/>
        <RegisterQuestion index={3} formData={formData} setFormData={setFormData}/>
        <RegisterQuestion index={4} formData={formData} setFormData={setFormData}/>

      </div>

         :""}
          
          {
          [ formData.MultipleAnswer01,
            formData.MultipleAnswer02,
            formData.MultipleAnswer03,
            formData.MultipleAnswer04
          ].includes(formData.Answer) || formData.AnswerTypeID == 1 ?
          
          <button id="AddValue" type="submit">Submit</button> :"" }
         </form>



    </div>
    :""}
  </div>
)
}

export default HandleAddRemove;