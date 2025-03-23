from mitmproxy import http

session_cookies = None

def response(flow: http.HTTPFlow):
    global session_cookies
    if "your_target_url" in flow.request.url:
        session_cookies = flow.response.headers.get("set-cookie")

def request(flow: http.HTTPFlow):
    global session_cookies
    if "your_target_url" in flow.request.url and session_cookies:
        flow.request.headers["Cookie"] = session_cookies