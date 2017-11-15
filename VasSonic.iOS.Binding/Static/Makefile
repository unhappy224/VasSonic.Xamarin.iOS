XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=Pods/Pods.xcodeproj
TARGET=VasSonic
DEPLOYMENTTARGET=8.0
NAME=VasSonic
CONFIG=Release
# SDKVERSION=11.0

all: $(NAME).framework

$(NAME)-x86.framework:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphonesimulator -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphonesimulator/$(TARGET)/$(TARGET).framework $@

$(NAME)-arm.framework:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphoneos -configuration $(CONFIG) clean build
	-mv $(PROJECT_ROOT)/build/$(CONFIG)-iphoneos/$(TARGET)/$(TARGET).framework/ $@

# lib$(NAME)-arm64.a:
# 	$(XBUILD) -project $(PROJECT) -target $(TARGET) IPHONEOS_DEPLOYMENT_TARGET='$(DEPLOYMENTTARGET)' ONLY_ACTIVE_ARCH=NO -sdk iphoneos -arch arm64 -configuration Release clean build
# 	-mv $(PROJECT_ROOT)/build/Release-iphoneos/$(TARGET)/$(TARGET).framework/$(TARGET) $@

$(NAME).framework: $(NAME)-arm.framework $(NAME)-x86.framework
	-rm -f $(NAME).framework
	-cp -r $(NAME)-arm.framework  $(NAME).framework
	lipo -create -output $(NAME).framework/$(NAME) $(NAME)-arm.framework/$(NAME) $(NAME)-x86.framework/$(NAME)
	# -mv $^ Output/$@
	# lipo -create -output $@ $^
	# -mv -f *.a ./Static
	# -rm -r $(PROJECT_ROOT)/build
	# sharpie bind --output=./Static/ApiDefinitions --namespace=$(NAME) --sdk=iphoneos$(SDKVERSION) ./VpnKeyChain/*.h

clean: 
	-rm -rf *.framework
	-rm -rf build
	-rm -rf Pods
	-rm -f Podfile.lock