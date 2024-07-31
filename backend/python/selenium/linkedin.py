from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.service import Service
import time
import json

class EasyApplyLinkedin:
    def __init__(self, data):
        self.email = data['email']
        self.password = data['password']
        self.keywords = data['keywords']
        self.location = data['location']

        s = Service(data['driver_path'])
        self.driver = webdriver.Chrome(service=s)

    def login_linkedin(self):
        self.driver.get("https://www.linkedin.com/login")

        login_email = self.driver.find_element(By.NAME, 'session_key')
        login_email.clear()
        login_email.send_keys(self.email)

        login_pass = self.driver.find_element(By.NAME, 'session_password')
        login_pass.clear()
        login_pass.send_keys(self.password)
        login_pass.send_keys(Keys.RETURN)
    
    def job_search(self):
        jobs_link = self.driver.find_element(By.LINK_TEXT,'Jobs')
        jobs_link.click()

        search_keywords = self.driver.find_element(By.CSS_SELECTOR,".search-global-typeahead__input[aria-label='Search']")
        search_keywords.clear()
        search_keywords.send_keys(self.keywords)


    def filter(self):
        #all_filters_button = self.driver.find_element(By.CSS_SELECTOR,".search-reusables__all-filters-pill-button")                                                   
        all_filters_button = self.driver.find_element(By.XPATH,"//button[@id=""ember769""]")
        all_filters_button.click()
        time.sleep(1)

        easy_apply_button = self.driver.find_element(By.XPATH,"//button[@id=""ember794""]")
        easy_apply_button.click()
        time.sleep(1)

    def find_offers(self):
        total_results = self.driver.find_element(By.CLASS_NAME,"display-flex.t-12.t-black--light.t-normal div span")
        total_results_int = int(total_results.text.split(' ',1)[0].replace(",",""))
        print(total_results_int)
        time.sleep(2)

    def close_session(self):
        print('End of the session.')
        self.driver.close()

    def apply(self):
        self.driver.maximize_window()
        self.login_linkedin()
        time.sleep(5)
        self.job_search()
        time.sleep(5)
        #self.filter()
        #time.sleep(2)
        #self.find_offers()
        #time.sleep(2)
        self.close_session()


if __name__ == '__main__':
    with open('config.json') as config_file:
        data = json.load(config_file)

    bot = EasyApplyLinkedin(data)
    bot.apply()