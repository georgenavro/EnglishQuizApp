import React,{useState} from "react";
import { FaTrash, FaEdit } from "react-icons/fa";
import axios from "axios";
import HandleAddRemove from "./AddRemoveFunction";

const DataTable = ({ data, columns, selection, allowUpdateDelete, setSuccessMessage,setErrorMessage,setReloadKey}) => {
  const jwtToken = localStorage.getItem("token");
  const [error,setError] = useState();
  const [updateAppeared,setUpdate] = useState(false);
  const [id, setID] = useState();
  const [updateClicked, setUpdateButtonChoice] = useState();
  const [IsUpdateMode,setIsUpdateMode] = useState(false);

  const handleEdit = (id) => {
    updateClicked !== id? setUpdateButtonChoice(id) : setUpdateButtonChoice(0);
   
    if(updateClicked === id){
      setUpdate(false);
     setIsUpdateMode(false);
    }
    else{ 
      setUpdate(true);
      setIsUpdateMode(true);
    }

    setID(id);

    //setIsUpdateMode(prev => !prev);
    
  }

  const handleDelete = async (id) => {
  console.log(id);
  const confirmed = window.confirm("Are you sure you want to delete this item?");
    if (!confirmed) return;
    else{
  try {
    const response = await axios.delete(`http://localhost:8095/${selection}/Delete`, {
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${jwtToken}`
      },
      params: {id}

    });

     setSuccessMessage("The item was deleted successfully.");
     setReloadKey(prev => prev+1); 
  } catch (error) {
      setError("Something went wrong. Please try again.");
      setReloadKey(prev => prev+1); 
      }
    }   
}
  
return (
  <div className="tableWrapper">
    {updateAppeared ?
    <div className="Add_Data">
    <div className="AddFieldForm">
    
    <HandleAddRemove id={id} selected={selection} setSuccessMessage={setSuccessMessage} setErrorMessage={setErrorMessage}
    isUpdateMode={IsUpdateMode} setReloadKey={setReloadKey}/>
    </div>
    </div>
    :""
    }
    <table>
      <thead>
        {selection ==="QA" ?
        
        <tr>
          
          <th>{columns[7].header}:{data[0][columns[7].accessor]}</th>
          <th>{columns[8].header}:{data[0][columns[8].accessor]}</th>
          
        </tr>
        : selection === "UserTest" ?
        <tr>
          <th>{columns[7].header}:{data[0][columns[7].accessor]}</th>
          <th>{columns[8].header}:{data[0][columns[8].accessor]}</th>
          <th>{columns[9].header}:{data[0][columns[9].accessor]}</th>
          <th>{columns[10].header}:{data[0][columns[10].accessor]}</th>
          
        </tr>
      :""}
        <tr>
          {columns.filter((col,i)=> {
            const skipIndexesQA = [3,4,5,6,7,8];
            const skipIndexsQA = [7,8]; 
            const skipIndexesUserTest = [3,4,5,6,7,8,9,10];
            const skipIndexesUserTests = [7,8,9,10];

            const shouldSkip = skipIndexesQA.includes(i) &&
            (selection ==="QA") &&
            data[0]?.[columns[8].accessor] === "Text" 
            || 
            skipIndexsQA.includes(i) &&
            (selection ==="QA") &&
            data[0]?.[columns[8].accessor] !== "Text"
            ||
            skipIndexesUserTest.includes(i) &&
            (selection === "UserTest") && 
            data[0]?.[columns[8].accessor] === "Text"
            ||
            skipIndexesUserTests.includes(i) &&
            selection === "UserTest" &&
            data[0]?.[columns[8].accessor] !== "Text";

            return !shouldSkip;
          }
        )
          .map((col, i) => (
            <th key={i}>{col.header}</th>
          ))}
        </tr>
      </thead>
      <tbody>
          
        {data.map((item, index) => (
          
          <tr key={index}>
           
            {columns
            .filter((col,i)=> {
              
            const skipIndexesQA = [3, 4, 5, 6, 7, 8];
            const skipIndexQA = [7,8];
            const skipIndexesUserTest = [3,4,5,6,7,8,9,10];
            const skipIndexesUserTests = [7,8,9,10];

        const shouldSkip =
          skipIndexesQA.includes(i) &&
          (selection === "UserTest" || selection === "QA") &&
          item[columns[8]?.accessor] === "Text" 
          || 
          skipIndexQA.includes(i)
           && (selection === "UserTest" || selection === "QA")
           && item[columns[8]?.accessor] !== "Text"
          ||
          skipIndexesUserTest.includes(i) &&
            (selection === "UserTest") && 
            item[columns[8]?.accessor] === "Text"
            ||
            skipIndexesUserTests.includes(i) &&
            (selection === "UserTest") &&
            item[columns[8]?.accessor] !== "Text";
         

        return !shouldSkip;
              
          } 
            )
            .map((col,i) => (
              
             <td key={i}>
              { typeof item[col.accessor] === "object"
                  ? item[col.accessor].userType
                  : item[col.accessor] }
             </td>
             
               ))}
             
              {allowUpdateDelete &&  (
              <td className="EditRemove">
                
                {selection !== "users" || data ?
                <button key={index} className={updateClicked === item[columns[0].accessor] ? "editButtonHasClicked" : ""} 
                onClick={()=>handleEdit(item[columns[0].accessor])}><FaEdit/></button> : ""}
                
                <button onClick={()=>handleDelete(item[columns[0].accessor])}><FaTrash/></button>
              </td>
              )}
            
          
          </tr>
          
        ))}
      </tbody>
    </table>
  </div>
);
};


export default DataTable;
