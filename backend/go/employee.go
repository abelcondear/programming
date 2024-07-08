package main

import (
	"fmt"
	"time"
	"math/rand"
	"math"

 )


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

type WorkingHours struct {
    Normal  float64 //capital letter : public member
    Short   float64
    Long    float64
}

func GetWorkingHours() *WorkingHours{
    var w = new(WorkingHours)
    w.Normal = 8.0
    w.Short = 4.0
    w.Long = 12.0
    return w 
}

func (e *Employee)rangeRand(max int, min int) int {
	return rand.Intn(max-min) + min
}

func (e *Employee)Quit() {
	e.timeEnd = time.Now().Local().Add(time.Hour * time.Duration(e.rangeRand(14,6)) + time.Minute * time.Duration(0) + time.Second * time.Duration(0)) // the variable type is defined in execution time
	
	fmt.Println(e.timeStart)
	fmt.Println(e.timeEnd)

	difference := e.timeEnd.Sub(e.timeStart)

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

	var workingHours = GetWorkingHours()
	newEmp.ExtraHoursWorked =  math.Abs(workingHours.Normal - newEmp.HoursWorked)

	fmt.Printf("Employee Name: %s\n", newEmp.Name)
	fmt.Printf("Employee Age: %.2d\n", newEmp.Age)
	fmt.Printf("Expected Hours to be Worked: %.2f\n", workingHours.Normal)	
	fmt.Printf("Hours Worked: %.2f\n", newEmp.HoursWorked)	
	fmt.Printf("Extra Hours Worked: %.2f\n", newEmp.ExtraHoursWorked)	
}
