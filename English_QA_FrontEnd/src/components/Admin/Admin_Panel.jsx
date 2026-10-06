import axios from "axios";
import React, {useState,useEffect } from "react";
import { useNavigate } from 'react-router-dom';
import "./../../../public/Admin_Panel.css";
import DataTable from "../Utils/AdminDataTables";
import tableConfigs from "../Utils/AdminTableConfigs";
import QuestionCategory from "../Utils/selectQuestionCategory";

function admin_dashboard(){

  const [data,setData] = useState([]);
  const [userData,setUserData] = useState([]);
  const [selection, setSelection] = useState(); 
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState();
  const [pageNumber,setPageNumber] = useState();
  const [activePage, setActivePage] = useState({
  currentPage: 0,
  currentPageUser: 0
  });
  const initialFormData = {
  questionCategoryID: 1,
  AnswerTypeID: 0,
};
  const [formData,setFormData] = useState(initialFormData);
  
  const [userID, setUserID] = useState();

  const navigate = useNavigate();
  const jwtToken = localStorage.getItem("token");
  

 useEffect(() => {
    const fetchData = async () => {
      
      try {
       setActivePage(prev => ({
    ...prev,
    currentPage: currentPage,
    currentPageUser: userID
    }));
      
      const paginationFilters = {
        pageNumber: currentPage,
        pageSize: 5
      };

      let paginationBody = {};

      if (selection === "QA") {
        paginationBody = {
          answerTypeID: formData.AnswerTypeID,
          questionCategoryID: formData.questionCategoryID
        };
      } else if (selection === "UserTest") {
        paginationBody = {
          answerTypeID: formData.AnswerTypeID,
          questionCategoryID: formData.questionCategoryID,
          userID: userID
        };
      } else {
        paginationBody = {
          userID: userID
        };
      }
    
      
        
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
        
      } catch (error) {
        console.error("error fetching data:", error);
      }
    };
if (formData.AnswerTypeID && formData.questionCategoryID || pageNumber || userID) {
    fetchData();
  }
  
  }, [formData.AnswerTypeID, formData.questionCategoryID, pageNumber,userID]);





function handlePageIndex(index) {
  
    setCurrentPage(index);
    setPageNumber(index);
  
}

function handleUserID(userID){
  setUserID(userID);
}


async function handleSelection(value){
  setSelection(value);
  
  if(value !== selection && value != "QA"){
  
  setData(null);
  setTotalPages(null);
  setUserID(null);
  switch(value){
    
case "TestResults":
case "UserTest":
case "users":{
try{

  const responseUsers = await axios.post("http://localhost:8095/Users/Get",2,{
    headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      },
  });
   setData(responseUsers.data);
   setUserData(responseUsers.data);
   console.log(formData.AnswerTypeID);
  }catch(error){
  console.error("error fetching data : " ,error);
}
 
}
break;

  default: {
      try{
   const response = await axios.get(`http://localhost:8095/${value}/Get`,{
    headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      }
  });
   setData(response.data);
   console.log(response);

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
        <option value="UserTest">User Tests</option>
        <option value="TestResults">Test Results</option>
      </select>
    </div>
    
    {data && selection && (
      
      <div>
        {selection === "QA" || selection === "UserTest" ?
    <div>

          <QuestionCategory 
          setFormData={setFormData} formData={formData} setCurrentPage={setCurrentPage}
           setPageNumber={setPageNumber} isUpdateMode={false} />

</div>
: ""}

{selection === "TestResults" || selection === "UserTest" ?
  
  <div className="paginationChangePageTestResults">
    {userData.map((item,index) => (
      <button className={activePage.currentPageUser === item.id ? "activeResult" : ""}
       onClick={() =>handleUserID(item.id)} key={index}>ID:{item.id},Name:{item.username}</button>
    ))}
    </div>
:""}
     
      <div>
        {console.log(data)}
        {data.length > 0 ?
        <DataTable data={data} columns={tableConfigs[selection]} selection={selection} allowUpdateDelete={false} /> :
        <div>
          <p>No results match your current filters.</p>
          
          </div>}
          
        </div>
     
        {((selection == "QA" || selection == "UserTest") && (formData.AnswerTypeID && formData.questionCategoryID))
         || (selection == "TestResults" && userID) ? 
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
      :""}
       </div>
    )}
  
 </div>
);
}

export default admin_dashboard;