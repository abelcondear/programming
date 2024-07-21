package main

import (
	"fmt"
	"time"
	"math/rand"
	"math"
	"bufio"
	"extra/workinghours"
	"container/list"
	"os"
	"sync"
)

var wg sync.WaitGroup

var listEmp *list.List
var listShift *list.List
var listContract *list.List
var countCall int = 0

type Shift struct {
	Name        string //capital letter : public member
	
	Start float64 
	End float64
}

type Contract struct {
	Name	string 	//capital letter : public member
}

type Employee struct {
	Name        string //capital letter : public member
	
	Age         int
	JobName 	string
	Salary      int
	
	HoursWorked float64
	ExtraHoursWorked float64

	timeStart time.Time //non-capital letter: private member
	timeEnd time.Time
}


func (e *Employee)rangeRand(max int, min int) int {
	return rand.Intn(max-min) + min
}

func (e *Employee)Quit() {
	e.timeEnd = time.Now().Local().Add(time.Hour * 
		time.Duration(e.rangeRand(14,6)) + 
		time.Minute * 
		time.Duration(0) + 
		time.Second * 
		time.Duration(0)) // the variable type is defined in execution time
	
	//fmt.Println(e.timeStart)
	//fmt.Println(e.timeEnd)

	difference := e.timeEnd.Sub(e.timeStart)

	e.HoursWorked = difference.Hours()
	return
}

func (e *Employee)Start() {
	e.timeStart = time.Now() // the variable type is defined in execution time	
	return
}

func PrintMenu()  {

	fmt.Printf("Enter option:")

	option := getInput()

	if  option == "1" { PrintNewEmployee() }
	if  option == "2" { PrintUpdateEmployee() }
	if  option == "3" { PrintDeleteEmployee() }
	if  option == "5" { PrintListEmployee() }
	if  option == "4" { os.Exit(0) }

}


func PrintListEmployee() {

	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value
		switch v := i.(type) {
		case Employee:
			fmt.Printf("New Name: %s\n", v.Name)
		}
	}

	fmt.Printf("\n\n")
	PrintMenu()
	
}

func PrintNewEmployee() {
	var text string
	var input string

	input = ""

	fmt.Printf("Name:")
	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		text = scanner.Text()
		if text != "" { 
			input = text 
			break
		}
		if text == "" {
			break
		}
	}

	var newEmp Employee

	newEmp.Name = input
	
	listEmp.PushBack(newEmp)

	countCall += 1

	if countCall == 4 {
		fmt.Printf("\n\n")
		PrintMenu()
	} else {
		fmt.Printf("\n\n")
		PrintNewEmployee()
	}

}

func PrintUpdateEmployee() {
	os.Exit(0)
}

func PrintDeleteEmployee() {
	os.Exit(0)
}

func getInput() string {
	var text string
	var data string

	scanner := bufio.NewScanner(os.Stdin)

	for scanner.Scan() {
		text = scanner.Text()
		if text != "" { 
			data = text 
			break
		}

		if text == "" {
			break
		}
	}
			
	return data
}

func addEmployee(addEmployeeFunc *sync.Mutex) {
	defer wg.Done()

	addEmployeeFunc.Lock()

	listEmp = list.New()	
	var newEmp Employee

	newEmp.Start()
	newEmp.Quit()	

	newEmp.Name = "John Mann"
	newEmp.Age = 39	

	var workingHours = workinghours.Get()
	newEmp.ExtraHoursWorked =  math.Abs(workingHours.Normal - newEmp.HoursWorked)

	listEmp.PushBack(newEmp) 

	newEmp.Start()
	newEmp.Quit()	

	newEmp.Name = "Mark London"
	newEmp.Age = 47	

	workingHours = workinghours.Get()
	newEmp.ExtraHoursWorked =  math.Abs(workingHours.Normal - newEmp.HoursWorked)

	listEmp.PushBack(newEmp) 

	n := 0
	
	for e := listEmp.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nEmployee List---------------\n\n")
		}

		switch v := i.(type) {
		case Employee:
			fmt.Printf("Employee Name: %s\n", v.Name)
			fmt.Printf("Employee Age: %.2d\n", v.Age)
			fmt.Printf("Expected Hours to be Worked: %.2f\n", workingHours.Normal)	
			fmt.Printf("Hours Worked: %.2f\n", v.HoursWorked)	
			fmt.Printf("Extra Hours Worked: %.2f\n", v.ExtraHoursWorked)	
			fmt.Printf("\n")
			//fmt.Printf("This is Employee type: %#v\n", v)
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addEmployeeFunc.Unlock()	
}

func addShift(addShiftFunc *sync.Mutex) {
	defer wg.Done()

	addShiftFunc.Lock()
	
	listShift = list.New()
	var newShift Shift

	newShift.Name = "Full Time" 
	newShift.Start = 9.0
	newShift.End = 18.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 9.0
	newShift.End = 14.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 14.0
	newShift.End = 19.0
	listShift.PushBack(newShift)

	newShift.Name = "Part-Time" 
	newShift.Start = 19.0
	newShift.End = 00.0
	listShift.PushBack(newShift)

	
	n := 0

	for e := listShift.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nShifts List-----------------\n\n")
		}

		switch v := i.(type) {
		case Shift:
			fmt.Printf("Shift Name: %s\n", v.Name)
			fmt.Printf("Shift Description: starts from %.2f to %.2f\n", v.Start, v.End)
			fmt.Printf("\n") 
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addShiftFunc.Unlock()
}

func addContract(addContractFunc *sync.Mutex) {
	defer wg.Done()

	addContractFunc.Lock()

	listContract = list.New()
	var newContract Contract

	newContract.Name = "Contract - 6 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 12 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 18 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - 24 Months"
	listContract.PushBack(newContract)
	newContract.Name = "Contract - Undetermined Time"
	listContract.PushBack(newContract)

	n := 0

	for e := listContract.Front(); e != nil; e = e.Next() {
		i := e.Value

		if n == 0 {
			fmt.Printf("\n\nContracts List -------------\n\n")
		}

		switch v := i.(type) {
		case Contract:
			fmt.Printf("Contract Name: %s\n", v.Name)
			fmt.Printf("\n")
		default:
			fmt.Printf("I don't know about type %T!\n", v)
		}

		n += 1
	}

	addContractFunc.Unlock()
} 

func main() {	
	
	// uncomment this in case you need to see the shift/contract/employee list
	wg.Add(3)

	addEmployeeFunc := &sync.Mutex{}
	addShiftFunc := &sync.Mutex{}
	addContractFunc := &sync.Mutex{}

	go addShift(addShiftFunc)
	go addContract(addContractFunc)
	go addEmployee(addEmployeeFunc)
	
	wg.Wait()

	

	//PrintMenu()

}
