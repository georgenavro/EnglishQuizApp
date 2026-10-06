import React,{useState,useEffect} from "react";
import axios from "axios";
import { json, useLocation } from "react-router-dom";
import "./../../../public/TestResults.css";
import { CgCloseO } from "react-icons/cg";

function TestResults(){
const location = useLocation();
const [getResultOfSelectionTest,setResultOfSelectionTest] = useState([]);
const [resultIndex,setResultIndex] = useState([]);
const [getAllTestResults, setAllTestResults] = useState([]);
const { data } = location.state || {};
const jwtToken = localStorage.getItem("token");
 const userID = localStorage.getItem("userID");
 const [error,setError] = useState("");
    
 useEffect(() => {
        if (data) {
          console.log(data);
          setResultOfSelectionTest(data);
        }
      }, [data]);

  useEffect(() => {
  const getAllResults = async () => {
    try {
     
      const response = await axios.post("http://localhost:8095/TestResults/GetAllTestResults",
        userID,
        {
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${jwtToken}`,
          },
        }
      );

      setAllTestResults(response.data);

    } catch (error) {
      console.error("Error fetching test results:", error);
    }
  };

  if (userID && jwtToken) {
    getAllResults(); // only call if dependencies are available
  }
}, [userID, jwtToken]);


  useEffect(() => {
  const fetchResults = async () => {
    try {
      const requestData = {
        userID,
        testCount: getResultOfSelectionTest.testCount,
      };
      const response = await axios.post(
        "http://localhost:8095/TestResults/GetTestResultSelection",
        requestData,
        {
          headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${jwtToken}`,
          },
        }
      );
      console.log("Data Submitted", response.data);
      setResultOfSelectionTest(response.data);
    } catch (error) {
      console.error("Error fetching test results:", error);
    }
  };

  if (userID && jwtToken && getResultOfSelectionTest?.testCount) {
    fetchResults();
  }
}, [userID, jwtToken, getResultOfSelectionTest]);


  async function GetTestResultSelection(testResultCounts,index){
     const request = {
            userID: userID,
            testResultCount: testResultCounts,
            };
            const response = await axios.post("http://localhost:8095/TestResults/GetTestResultSelection", request, {
              headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${jwtToken}`  // Ensure JSON content type is set
              }});  
              if(response.status === 400){
                setError("");}
                setResultIndex(index);
            console.log("Data submitted:", response.data);
            setResultOfSelectionTest(response.data);
            if (response.data) {
            window.scrollTo({ top: 0, behavior: "smooth" });
            }
      }
  async function removeTestResultSelection(testResultCount){
       const response = await axios.delete("http://localhost:8095/TestResults/Delete", {
            headers: {
              "Content-Type": "application/json",
              "Authorization": `Bearer ${jwtToken}`
            },
            data: testResultCount
          });
              if(response.status === 404){
                setError("There Aren't any results to remove");}
                else if(response.status === 204){
                  console.log("Data removed");
                  window.location.reload();
                }
            

            window.scrollTo({ top: 0, behavior: "smooth" });

  }
  async function removeAllTestResults(){
       const response = await axios.delete("http://localhost:8095/TestResults/DeleteAll", {
            headers: {
              "Content-Type": "application/json",
              "Authorization": `Bearer ${jwtToken}`
            }
            ,data: userID
            });
              if(response.status === 404){
                setError("There Aren't any results to remove");
              }

              else if(response.status === 204){
                  console.log("Data removed");
                  window.location.reload();
              }
            

            window.scrollTo({ top: 0, behavior: "smooth" });

  }
    
    return (
        <div className="testResults">
  {getAllTestResults && getAllTestResults.length > 0 ? (
    <div className="previousTestResults">
      <p className="fault">{error}</p>
      <span className="title"><p>Your previous results are:</p>
      <button className="previousResultTestButton"
            onClick={removeAllTestResults}>Remove All Results</button></span>
      
      {getAllTestResults.map((item, index) => (
        <div className="PreviousResults" key={index}>
          <p>{index+1}</p>
          <span className="testButtonWrap"><button
            value={`testResultPreviousButton_${index}`}
            className="previousResultTestButton"
            onClick={() => GetTestResultSelection(item.testResultCount,index+1)}>
            Test Per Attempt: {item.testPerAttempt}, Your Score:{item.results}, TestID:{item.userTest.testCount}
            </button>

          <button value={`removeTestButton_${index}`}
            className="removePreviousTestResultButton"
            onClick={() => removeTestResultSelection(item.testResultCount)}>
            <span className="removeIcon"><CgCloseO/></span></button></span>
        </div>
        
      ))}
      
    </div>
  ) : (
    <div className="previousTestResults">
    <p>There aren't any results yet</p>
    </div>
  )}
  {getResultOfSelectionTest && getResultOfSelectionTest.length > 0 ? (
  <div className="testResultSelection">
    <p>Your {resultIndex} test results:</p>
    <table>
      <thead>
        <tr>
          <th>Right Answer</th>
          <th>User Answer</th>
          <th>Results</th>
        </tr>
      </thead>
      <tbody>
        {getResultOfSelectionTest.map((item, index) => (
          <tr key={index}>
            <th>{item.userTest.answer}</th>
            <th>{item.userAnswer}</th>
            <th>{item.results}</th>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
) : (
  <div className="testResultSelection">
    <p>There aren't any results yet</p>
  </div>
)}
</div>
    )
}
export default TestResults;