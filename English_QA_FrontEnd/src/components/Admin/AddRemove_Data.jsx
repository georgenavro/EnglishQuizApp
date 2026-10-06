import React, {useState,useEffect} from "react";
import { useNavigate } from 'react-router-dom';
import "../../../public/AddRemove_Data.css";
import { CgAdd } from "react-icons/cg";
import { CgCloseO } from "react-icons/cg";
import axios, { Axios } from "axios";
import DataTable from "../Utils/AdminDataTables";
import tableConfigs from "../Utils/AdminTableConfigs";
import HandleAddRemove from "../Utils/AddRemoveFunction";
import QuestionCategory from "../Utils/selectQuestionCategory";

function AddRemove_Data(){
  const [selection,setSelection] = useState();
  const navigate = useNavigate();
  const jwtToken = localStorage.getItem("token");
  const [data,setData] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState();
  const [pageNumber,setPageNumber] = useState();
  const [successMessage,setSuccessMessage] = useState("");
  const [errorMessage, setErrorMessage] = useState("");
  const [reloadKey, setReloadKey] = useState(0);
  

  const [showField,setShowFields] = useState({
    ButtonOn: false,
    userSelection: "",
  });
  const [formData,setFormData] = useState({
    questionCategoryID: 1,
    AnswerTypeID: 0
  });
  
  const [activePage, setActivePage] = useState({
    currentPage: 0
    });

  const handleClick = () => {

     setShowFields(prev => ({
    ...prev,
    ButtonOn: !prev.ButtonOn
  }));
  }
  
  function handlePageIndex(index){
  setCurrentPage(index);
  setPageNumber(index);

  }

   useEffect(() => {
      if(selection !== "QA" && reloadKey){
        handleSelection(selection);
      }
    },[reloadKey]);

 useEffect(() => {
    const fetchData = async () => {
     
       setActivePage(prev => ({
    ...prev,
    currentPage: currentPage
    }));

      const paginationFilters = {
        pageNumber: currentPage,
        pageSize: 5
      };

      let paginationBody = {}

           paginationBody = {
          answerTypeID: formData.AnswerTypeID,
          questionCategoryID: formData.questionCategoryID
        }
      

      try {
        const response = await axios.post(
          `http://localhost:8095/${selection}/pagination`,
          paginationBody,
          {
            headers: {
              "Content-Type": "application/json",
              "Authorization": `Bearer ${jwtToken}`
            },
            params: paginationFilters
          }
        );

        setData(response.data.data);
        setTotalPages(response.data.totalPages);
        setReloadKey(0);
      } catch (error) {
        console.error("error fetching data:", error);
      }
    };
if ((formData.AnswerTypeID && formData.questionCategoryID) || pageNumber || (selection === "QA" && reloadKey)) {
    fetchData();
  }
  }, [formData.AnswerTypeID, formData.questionCategoryID, pageNumber, reloadKey]);


async function handleSelection(selected){
  
  setSelection(selected);
  
  if(selected === selection && !reloadKey){
    setSuccessMessage("");
    setErrorMessage("");
  }
  else{
  switch(selected){
    case "AnswerType":
    case "UserType":
    case "QuestionCategory":{
      try{
      const response = await axios.get(`http://localhost:8095/${selected}/Get`,{
        headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      }
      });
      
       setData(Array.isArray(response.data) ? response.data : [response.data]);
       setReloadKey(0);
      
    }catch(error){
      console.error("error fetching data : " ,error);
    }
    }
    break;

    case "users":{

  try{

  const responseUsers = await axios.post("http://localhost:8095/Users/Get",2,{
    headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      },
  });
  
    setData(Array.isArray(responseUsers.data) ? responseUsers.data : [responseUsers.data]);
    setReloadKey(0);
   //setUserData(responseUsers.data);
  }catch(error){
  console.error("error fetching data : " ,error);
  }
 
  }
  break;
  
  
  }

}

}

return (
  <div>
    <p>Welcome Admin</p>
    <div className="selectTable">
      <select onClick={(e) => handleSelection(e.target.value)}>
        <option value="AnswerType">Answer Type</option>
        <option value="QuestionCategory">Question Category</option>
        <option value="users">Users</option>
        <option value="UserType">User Type</option>
        <option value="QA">Questions Answers</option>
      </select>
    </div>
    <div>
     <p className={successMessage ? "" : "alert_messages"}>{successMessage}</p>
     <p className={errorMessage ? "" : "alert_messages"}>{errorMessage}</p>
     </div>
  {/* Insert data into the table */}
   {data && selection !== undefined && selection !== "QA" ?
   <div>
    <div className="Add_Data">
      
      <button onClick={handleClick}>{showField.ButtonOn === false ? <CgAdd id="AddValue"/> : <CgCloseO id="CancelORRemove"/>  }</button>
      {showField.ButtonOn ?
      <div className="AddFieldForm">
      <HandleAddRemove selected={selection} setSuccessMessage={setSuccessMessage} 
      setErrorMessage={setErrorMessage} setReloadKey={setReloadKey}/>
      </div>
      :""}
      
      </div>
      <div>
      <DataTable data={data} columns={tableConfigs[selection]} selection={selection}
       setSuccessMessage={setSuccessMessage} allowUpdateDelete={true} setReloadKey={setReloadKey} />
    </div>
    </div>
  : data && selection === "QA" ?
  <div>
  <div className="Add_Data">
      <button onClick={handleClick}>{showField.ButtonOn == false ? <CgAdd id="AddValue"/> : <CgCloseO id="CancelORRemove"/> }</button>
      {showField.ButtonOn ?
      <div className="AddFieldForm">
      <HandleAddRemove selected={selection} setSuccessMessage={setSuccessMessage} 
      setErrorMessage={setErrorMessage} setReloadKey={setReloadKey}/>
      </div>
      :""}
      </div>
  {/* End of the add-data section */}
      {/* User selects the AnswerTypeID and questionCategoryID */}
          <QuestionCategory 
         setFormData={setFormData} formData={formData} setCurrentPage={setCurrentPage} 
         setPageNumber={setPageNumber} isUpdateMode={false} />
         {/* Table results */}
      <div>
        {data.length > 0 ?
       <DataTable data={data} columns={tableConfigs[selection]} selection={selection} allowUpdateDelete={true}
       setSuccessMessage={setSuccessMessage} setReloadKey={setReloadKey} /> :
        <div>
          <p>No results match your current filters.</p>
         
          </div>}
      
    </div>
        
        {/* Pagination pages */}
         <div className="paginationChangePage">
          {[...Array(totalPages)].map((_, index) => (
            <button
              key={index}
              className={activePage.currentPage === index + 1 ? "active" : ""}
              onClick={() => handlePageIndex(index + 1)}
            >
              {index+1}
            </button>
          ))}
        
      </div>

    </div>
      :""}
    </div>
    
)
}


export default AddRemove_Data;