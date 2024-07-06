package main



import (
	"fmt"
	//"math"
	"time"
 )

type Employee struct {
	Name        string //capital letter : public member
	
	Age         int
	JobName 	string
	Salary      int
	
	HoursWorked float64

	timeStart time.Time //non-capital letter: private member
	timeEnd time.Time
}

func (e *Employee)Quit() {
	e.timeEnd = time.Now() // the variable type is defined in execution time
	
	fmt.Println(e.timeStart)
	fmt.Println(e.timeEnd)

	difference := e.timeEnd.Sub(e.timeStart)
	fmt.Println(difference)

	e.HoursWorked = difference.Hours()
	return
}

func (e *Employee)Start() {
	e.timeStart = time.Now() // the variable type is defined in execution time
	
	return
}

func main() {
	var newEmp = new(Employee)

	newEmp.Start()
	newEmp.Quit()

	newEmp.Name = "John Mann"
	newEmp.Age = 34

	fmt.Printf("Employee Name: %s\n", newEmp.Name)
	fmt.Printf("Employee Age: %.2d\n", newEmp.Age)
	fmt.Printf("Hours worked: %.2f\n", newEmp.HoursWorked)	
}
