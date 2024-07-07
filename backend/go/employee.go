package main

import (
	"fmt"
	"time"
	"math/rand"
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
	e.timeEnd = time.Now().Local().Add(time.Hour * time.Duration(rand.Intn(12-6) + 6) + time.Minute * time.Duration(0) + time.Second * time.Duration(0)) // the variable type is defined in execution time
	
	fmt.Println(e.timeStart)
	fmt.Println(e.timeEnd)

	difference := e.timeEnd.Sub(e.timeStart)
	//fmt.Println(difference)

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
	fmt.Printf("Hours Worked: %.2f\n", newEmp.HoursWorked)	
}
